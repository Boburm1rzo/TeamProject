using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TeamProject
{
    internal partial class BotManage
    {
        private static HouseData _houseData;
        private static Dictionary<string, string> datas = new Dictionary<string, string>
        {
            {"Rayon" ,null },
            {"Kim uchun" ,null},
            {"Uy manzili" ,null },
            {"Xonalar soni",null },
            {"Narxi",null }
        };
        public async static Task OnUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            //return;
            if(update.CallbackQuery != null)
            {
                await OnCallBackAsync(client,update,token);
            }
            else if(update.Message.Type is MessageType.Text)
            {
                await OnTextAsync(client,update.Message, token);
            }     
            else if(update.Message.Type is MessageType.Location)
            {
                await OnLocationAsync(client,update.Message, token);
            }
            else if(update.Message.Type is MessageType.Photo)
            {
                await OnPhotoAsync(client, update.Message, token);
            }
            else if(update.Message.Type is MessageType.Contact)
            {
                await OnContactAsync(client, update, token);
            }
        }
           
    }
}
