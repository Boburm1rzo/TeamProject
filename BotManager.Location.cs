using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace TeamProject
{
    internal partial class BotManage
    {
        async static Task OnLocationAsync(ITelegramBotClient client, Message message, CancellationToken token)
        {
            _houseData.Latitude = message.Location.Latitude;
            _houseData.Longtitude = message.Location.Longitude;
            
            await client.SendTextMessageAsync(
                message.Chat.Id,
                "Uyning Rasmini yuboring");
            await client.DeleteMessageAsync(message.Chat.Id, message.MessageId - 1);
            await client.DeleteMessageAsync(message.Chat.Id, message.MessageId);
        }
    }
}
