using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.Contract;
using CanDatabaseManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CanDatabaseManagementSystem.Service
{
    public class DbcFileParserService : IDbcFileParserService
    {
        private const string networkNodeStartMark = "BU_: ";
        private const string messageStartMark = "BO_ ";
        private const string signalStartMark = "SG_ ";
        private Message currentMessage = null;
        public async Task<DbcFile> Parse(DbcFileData dbcFileData)
        {
            var dbcFile = new DbcFile();
            var networkNodes = new List<NetworkNode>();
            var messages = new List<Message>();

            using (StringReader reader = new StringReader(dbcFileData.Data))
            {
                string line;
                bool networkNodeStart = false;
                bool messageStart = false;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if(currentMessage != null)
                        {
                            messages.Add(currentMessage);
                            currentMessage = null;
                        }
                        networkNodeStart = false;
                        messageStart = false;
                    }
                    else if (line.Contains(networkNodeStartMark))
                    {
                        networkNodeStart = true;
                        networkNodes.Add(await ParseNetworkNode(line));
                    }
                    else if (networkNodeStart)
                    {
                        networkNodes.Add(await ParseNetworkNode(line));
                    }
                    else if (line.Contains(messageStartMark))
                    {
                        messageStart = true;
                        await ParseMessage(line);
                    }
                    else if (messageStart)
                        await ParseSignal(line);
                }
            }
            if(currentMessage != null)
                messages.Add(currentMessage);
            dbcFile.Name = dbcFileData.FileName;
            dbcFile = AddAllNetworkNodes(dbcFile, networkNodes);
            dbcFile = AddAllMessages(dbcFile, messages);

            return dbcFile;
        }
        private async Task<NetworkNode> ParseNetworkNode(string text)
        {
            var networkNode = new NetworkNode();
            var splittedText = text.Split(' ');
            networkNode.Name = splittedText[1];

            return networkNode;
        }
        private async Task ParseMessage(string text)
        {
            var message = new Message();
            var splittedText = text.Split(' ');
            message.CanMessageId = Int64.Parse(splittedText[1]);
            message.Name = splittedText[2];
            currentMessage = message;
        }
        private async Task ParseSignal(string text)
        {
            var signal = new Signal();
            var splittedText = text.Split(' ');
            var splittedTextByLine = splittedText[4].Split('|');
            var splittedTextByMark = splittedTextByLine[1].Split('@');
            signal.Name = splittedText[2];
            signal.StartBit = int.Parse(splittedTextByLine[0]);
            signal.Lenght = int.Parse(splittedTextByMark[0]);

            currentMessage.Signals.Add(signal);
        }
        private DbcFile AddAllMessages(DbcFile dbcFile, List<Message> messages)
        {
            foreach (var message in messages)
            {
                dbcFile.Messages.Add(message);
            }

            return dbcFile;
        }
        private DbcFile AddAllNetworkNodes(DbcFile dbcFile, List<NetworkNode> nodes)
        {
            foreach (var node in nodes)
            {
                dbcFile.NetworkNodes.Add(node);
            }

            return dbcFile;
        }
    }
}
