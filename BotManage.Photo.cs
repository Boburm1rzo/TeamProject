using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace TeamProject
{
    internal partial class BotManage
    {
        public async static Task OnPhotoAsync(ITelegramBotClient client, Message message, CancellationToken token)
        {
            if(message.Photo is not null)
            {
                _houseData.Photos = new List<string>();
                string fileId = message.Photo[0].FileId;
                if(message.Photo.Last() is not null) 
                    _houseData.Photos.Add(fileId);
            }
            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(new KeyboardButton[]
            {
                KeyboardButton.WithRequestContact("📞 Kontaktni yuborish")
            })
            { OneTimeKeyboard=true,ResizeKeyboard=true};
           await client.SendTextMessageAsync(
                message.Chat.Id,
                "<strong>📞Telfon raqamingizni yuboring</strong>",
                 parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,replyMarkup:replyKeyboardMarkup) ;
            await client.DeleteMessageAsync(message.Chat.Id, message.MessageId - 1);
            await client.DeleteMessageAsync(message.Chat.Id, message.MessageId);
        }
    }
}
