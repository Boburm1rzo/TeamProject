using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TeamProject;

internal partial class BotManage
{
    async static Task OnTextAsync(ITelegramBotClient client, Message message, CancellationToken token)
    {

        List<string> rayons = new List<string>()
        {
            "Olmazor","Bektemir","Mirobod","Mirzo Ulug'bek","Sergili","Chilonzor",
            "Shayxontoxur","Yunus Obod","Yakka Saroy","Yashnabod","Uchtepa","Yangi Hayot"
        };
       
        switch (message.Text)
        {
            case "/start":
                ReplyKeyboardMarkup replyKeyboard = new ReplyKeyboardMarkup(new KeyboardButton[]
               {
                    "🏘Ijara izlash","🏠Ijaraga uy qo'yish"
               })
                {
                    OneTimeKeyboard = true,
                    ResizeKeyboard = true
                };
                await client.SendTextMessageAsync(
                   message.Chat.Id,
                   text: "<strong>Assalomu aleykum botimizga xush kelibsiz</strong>",
                   cancellationToken: token,
                   replyMarkup: replyKeyboard,
                   parseMode:ParseMode.Html);

                await client.DeleteMessageAsync(message.Chat.Id, message.MessageId );

                break;
            case "🏠Ijaraga uy qo'yish":
                #region clear dic
                datas["Rayon"] = null;
                datas["Kim uchun"] = null;
                datas["Uy manzili"] = null;
                datas["Xonalar soni"] = null;
                datas["Narxi"] = null;
                #endregion
                replyKeyboard = new ReplyKeyboardMarkup(new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        "Olmazor","Bektemir","Mirobod",
                    },
                    new KeyboardButton[]
                    {
                        "Mirzo Ulug'bek","Sergili","Chilonzor"
                    },
                    new KeyboardButton[]
                    {
                         "Shayxontoxur","Yunus Obod","Yakka Saroy"
                    },
                    new KeyboardButton[]
                    {
                        "Yashnabod","Uchtepa","Yangi Hayot"
                    }
                })
                {
                    OneTimeKeyboard=true, ResizeKeyboard=true
                };
                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "<strong>📄Rayonni kiriting</strong>",
                    replyMarkup:replyKeyboard,
                    parseMode:ParseMode.Html);

                await client.DeleteMessageAsync(message.Chat.Id, message.MessageId - 1);
                await client.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                break;
            case "🏘Ijara izlash":
                InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        InlineKeyboardButton.WithCallbackData("Olmazor","Olmazor"),
                        InlineKeyboardButton.WithCallbackData("Bektemir","Bektemir"),
                        InlineKeyboardButton.WithCallbackData("Mirobod","Mirobod"),
                    },
                    new InlineKeyboardButton[]
                    {
                        InlineKeyboardButton.WithCallbackData("Chilonzor","Chilonzor"),
                        InlineKeyboardButton.WithCallbackData("Mirzo Ulug'bek","Mirzo Ulug'bek"),
                        InlineKeyboardButton.WithCallbackData("Sergili","Sergili"),
                    },
                    new InlineKeyboardButton[]
                    {
                        InlineKeyboardButton.WithCallbackData("Shayxontoxur","Shayxontoxur"),
                        InlineKeyboardButton.WithCallbackData("Yakka Saroy","Yakka Saroy"),
                        InlineKeyboardButton.WithCallbackData("Yunus Obod","Yunus Obod"),
                    },
                    new InlineKeyboardButton[]
                    {
                        InlineKeyboardButton.WithCallbackData("Yashnabod","Yashnabod"),
                        InlineKeyboardButton.WithCallbackData("Uchtepa","Uchtepa"),
                        InlineKeyboardButton.WithCallbackData("Yangi Hayot","Yangi Hayot"),
                    }
                });
                await client.SendTextMessageAsync(
                    message.Chat.Id,
                    "<strong>📄Qaysi rayondan tanlamoqchisiz</strong>",
                    replyMarkup: inlineKeyboard,
                    parseMode:ParseMode.Html);

                await client.DeleteMessageAsync(message.Chat.Id, message.MessageId - 1);
                await client.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                break;
            case "⬅️Asosiy menyuga":
                replyKeyboard = new ReplyKeyboardMarkup(new KeyboardButton[]
              {
                    "🏘Ijara izlash","🏠Ijaraga uy qo'yish"
              })
                {
                    OneTimeKeyboard = true,
                    ResizeKeyboard = true
                };
                await client.SendTextMessageAsync(
                   message.Chat.Id,
                   text: "<strong>Bosh menyu</strong>",
                   replyMarkup: replyKeyboard, parseMode: ParseMode.Html);

                await client.DeleteMessageAsync(message.Chat.Id, message.MessageId - 1);
                await client.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                break;
            case "/menu":
                replyKeyboard = new ReplyKeyboardMarkup(new KeyboardButton[]
              {
                    "🏘Ijara izlash","🏠Ijaraga uy qo'yish"
              })
                {
                    OneTimeKeyboard = true,
                    ResizeKeyboard = true
                };
                await client.SendTextMessageAsync(
                   message.Chat.Id,
                   text: "<strong>Bosh menyu</strong>",
                   replyMarkup: replyKeyboard, parseMode: ParseMode.Html);

                await client.DeleteMessageAsync(message.Chat.Id, message.MessageId - 1);
                await client.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                break;
            default:
                if (datas["Rayon"] is null)
                {
                    datas["Rayon"] = message.Text;
                    replyKeyboard = new ReplyKeyboardMarkup(new KeyboardButton[][]
                    {
                        new KeyboardButton[]
                        {
                            "Qizlar","Oila","Bollar"
                        }
                    })
                    {
                        OneTimeKeyboard = true,
                        ResizeKeyboard = true
                    };
                    await client.SendTextMessageAsync(
                        message.Chat.Id,
                        "<strong>👤Kim uchun</strong>:",
                        replyMarkup: replyKeyboard,
                        parseMode:ParseMode.Html);
                    await client.DeleteMessageAsync(message.Chat.Id, message.MessageId - 1);
                    await client.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                }
                else if (datas["Kim uchun"] is null)
                {
                    datas["Kim uchun"] = message.Text;
                    await client.SendTextMessageAsync(
                        message.Chat.Id,
                        "<strong>📫Uy manzilini kiriting</strong>:",
                        parseMode: ParseMode.Html);
                    await client.DeleteMessageAsync(message.Chat.Id, message.MessageId - 1);
                    await client.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                }
                else if (datas["Uy manzili"] is null)
                {
                    datas["Uy manzili"] = message.Text;
                    await client.SendTextMessageAsync(
                        message.Chat.Id,
                        "<strong>🚪Xonalar sonini kiriting</strong>:",
                        parseMode:ParseMode.Html);
                    await client.DeleteMessageAsync(message.Chat.Id, message.MessageId - 1);
                    await client.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                }
                else if (datas["Xonalar soni"] is null)
                {
                    datas["Xonalar soni"] = message.Text;
                    await client.SendTextMessageAsync(
                        message.Chat.Id,
                        "<strong>💰Narxini kiriting(oylik)</strong>:",parseMode:ParseMode.Html);
                    await client.DeleteMessageAsync(message.Chat.Id, message.MessageId - 1);
                    await client.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                }
                else if (datas["Narxi"]is null)
                {
                    datas["Narxi"] = message.Text;
                    _houseData.UyManzili = datas["Uy manzili"];
                    _houseData.Xona = datas["Xonalar soni"];
                    _houseData.Rayon = datas["Rayon"];
                    _houseData.ForWhom = datas["Kim uchun"];
                    _houseData.Pul = datas["Narxi"];
                    replyKeyboard = new ReplyKeyboardMarkup(new KeyboardButton[]
                    {
                        KeyboardButton.WithRequestLocation("📍Lokatsiyani yuborish")
                    })
                    { 
                    OneTimeKeyboard= true,
                    ResizeKeyboard = true
                    };
                    await client.SendTextMessageAsync(
                        message.Chat.Id,
                        "<strong>📍Geo-Lokatsiyani yuboring</strong>:",
                        replyMarkup: replyKeyboard, parseMode: ParseMode.Html);
                    await client.DeleteMessageAsync(message.Chat.Id, message.MessageId - 1);
                    await client.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                }
                break;
        }
    }
}