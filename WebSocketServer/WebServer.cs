using System;
using Fleck;
namespace WebSocketServer
{
    public  class WebServer
    {
        public void SendData()
        {
            var server = new Fleck.WebSocketServer("ws://127.0.0.1:8081/");
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("Open!");
                };

                socket.OnMessage = message =>
                {
                    Console.WriteLine(message);
                    if (message.StartsWith("Venda"))
                    {
                        string[] dados = message.Split('|');

                        //abrir conexão com o banco de dados SQL.
                        //Verificar o pedido 

                        //Resposta para o cliente
                        socket.Send("Confirmado");
                    }
                };

                socket.OnClose = () =>
                {
                    Console.WriteLine("Close!");
                };

            });

            Console.ReadKey();
        }
    }
}
