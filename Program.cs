using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
namespace TeamProject
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            TelegramBotClient client = new TelegramBotClient(@"7068640634:AAEmrDZjvHiEEFdzlCASR9ou7ppYS3aFRTo");
            ReceiverOptions options = new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };
            client.StartReceiving(
                updateHandler: UpdateHandlingAsync,
                pollingErrorHandler: ErrorHandlingAsync,
                receiverOptions: options);
            
            Console.ReadKey();
        }

        private static Task ErrorHandlingAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        private async static Task UpdateHandlingAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            //return;
           await BotManage.OnUpdateAsync(client, update, token);  
        }

    }
}

