﻿namespace br.com.deveficiente.mercadolivre.Domain.NotificationObjects
{
    public class Notification
    {
        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }
        public string Message { get; set; }
    }
}
