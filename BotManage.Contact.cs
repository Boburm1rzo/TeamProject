using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TeamProject
{
    internal partial class BotManage
    {
        public async static Task OnContactAsync(ITelegramBotClient client,Update update,CancellationToken token)
        {
            _houseData.UserName= update.Message.From.Username;
            _houseData.PhoneNumber=update.Message.Contact.PhoneNumber;
            List<HouseData> house = await WorkingWithFile.ReadToFile();
            house.Add(_houseData);
            await WorkingWithFile.WriteToFile(house);
            ReplyKeyboardMarkup reply = new ReplyKeyboardMarkup(new KeyboardButton[]
            {
                "⬅️Asosiy menyuga"
            })
            {
                OneTimeKeyboard = true,
                ResizeKeyboard = true,
            };
            
            await client.SendTextMessageAsync(
                update.Message.Chat.Id,
                "<strong>✅E'lon qabul qilindi</strong>",
                replyMarkup: reply, parseMode: Telegram.Bot.Types.Enums.ParseMode.Html);
            await client.DeleteMessageAsync(update.Message.Chat.Id, update.Message.MessageId - 1);
            await client.DeleteMessageAsync(update.Message.Chat.Id, update.Message.MessageId);

        }
    }
}
