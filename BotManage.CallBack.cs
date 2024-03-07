using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

namespace TeamProject
{
    internal partial class BotManage
    {
        public async static Task OnCallBackAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            CallbackQuery callbackQuery = update.CallbackQuery;
            List<HouseData> houseData = await WorkingWithFile.ReadToFile();
            List<HouseData> data = new List<HouseData>();
            foreach(HouseData house in houseData) 
                if(house.Rayon==callbackQuery.Data)
                    data.Add(house);
            int count=data.Count();
            for(int i=0;i<count; i++)
            {
                string txt = $"📄Rayon:  {data[i].Rayon}\n" +
                    $"📫Manzil:  {data[i].UyManzili}\n" +
                    $"🚪Xonalar soni:  {data[i].Xona}\n" +
                    $"👤Kim uchun:  {data[i].ForWhom}\n" +
                    $"💰Narxi:  {data[i].Pul}\n" +
                    $"📞Tel raqam:  {data[i].PhoneNumber}" +
                    $"📩tg:  @{data[i].UserName}\n" +
                    $"📍quyida lokatsiyasi";
                
                await client.SendPhotoAsync(callbackQuery.Message.Chat.Id, photo: InputFile.FromFileId(data[i].Photos[0]), caption: txt);
                await client.SendLocationAsync(callbackQuery.Message.Chat.Id, latitude: data[i].Latitude, longitude: data[i].Longtitude);
            }
            ReplyKeyboardMarkup replyKeyboard= new ReplyKeyboardMarkup(new KeyboardButton[]
            {
                "⬅️Asosiy menyuga"
            })
            {
                OneTimeKeyboard=true,
                ResizeKeyboard=true
            };
            await client.SendTextMessageAsync(callbackQuery.Message.Chat.Id,
                $"<strong>Hozircha {callbackQuery.Data} rayonidan bor uylar shular</strong>",
                replyMarkup: replyKeyboard,parseMode:ParseMode.Html);
            await client.DeleteMessageAsync(callbackQuery.Message.Chat.Id, callbackQuery.Message.MessageId);
            //switch (callbackQuery.Data)
            //{
            //    case "Chilonzor":

            //        var labelDataPairs = new List<(string Label, string Data)>
            //            {
            //                ("« 1", "first"),
            //                ("‹ 3", "prev"),
            //                ("· 4 ·", "stay"),
            //                ("5 ›", "next"),
            //                ("31 »", "last"),
            //            };
            //        var buttonRow = labelDataPairs.Select(
            //            pair => InlineKeyboardButton.WithCallbackData(pair.Label, pair.Data)).ToArray();

            //        var keyboard = new InlineKeyboardMarkup(buttonRow);

            //        await client.SendTextMessageAsync(
            //            chatId:update.CallbackQuery.Message.Chat.Id,
            //            text:"asda",
            //            replyMarkup: keyboard,
            //            cancellationToken:token);



            //        break;
            //    case "Olmazor":
            //        break;
            //    case "Bektemir":
            //        break;
            //    case "Mirobod":

            //        break;
            //    case "Mirzo Ulug'bek":

            //        break;
            //    case "Sergili":
            //        break;
            //    case "Shayxontoxur":
            //        break;
            //    case "Yunus Obod":
            //        break;
            //    case "Yakka Saroy":
            //        break;
            //    case "Yashnabod":
            //        break;
            //    case "Uchtepa":
            //        break;
            //    case "Yangi Hayot":
            //        break;
            //}
        }
    }
}
