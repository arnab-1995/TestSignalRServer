using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TestSignalRServer
{
    public class TestHub : Hub
    {
        public async Task TestUpstream(ChannelReader<object> stream)
        {
            try
            {
                while (await stream.WaitToReadAsync())
                {
                    while (stream.TryRead(out object item))
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while reading from stream, Exception: " + ex.Message);
            }
        }
    }
}
