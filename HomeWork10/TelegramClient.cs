using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace HomeWork10
{
    class TelegramClient
    {
        public MainWindow Main;
        public ObservableCollection<Message> BotMessage;

        private void MessageListener(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Text);

            Main.Dispatcher.Invoke(() =>
            {
                BotMessage.Add(
                new Message(
                    e.Message.Chat.FirstName, e.Message.Text, DateTime.Now, e.Message.Chat.Id));
            });

        }

        TelegramBotClient bot;

        public TelegramClient(MainWindow main, string token = "****")
        {
            this.Main = main;
            this.BotMessage = new ObservableCollection<Message>();           
            bot = new TelegramBotClient(token);
            bot.OnMessage += MessageListener;
            bot.StartReceiving();
        }

        public void SendMessage(string Text, string Id)
        {
            long id = Convert.ToInt64(Id);
            bot.SendTextMessageAsync(id, Text);
        }
    }
}
