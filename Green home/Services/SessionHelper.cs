﻿using System.Text.Json;
namespace Green_home.Services
{
    public class NoSessionObjectException : ArgumentException
    {
        public NoSessionObjectException()
        {
        }

        public NoSessionObjectException(string? message) : base(message)
        {
        }
    }
    public static class SessionHelper
    {

        public static T Get<T>(T t, HttpContext context)
        {
            String sessionName = nameof(t);
            String? s = context.Session.GetString(sessionName);
            // if (string.IsNullOrWhiteSpace(s))
            // {
            //     throw new NoSessionObjectException($"No session {sessionName}");
            // }
            return JsonSerializer.Deserialize<T>(s);

        }
        public static void Set<T>(T t, HttpContext context)
        {
            String sessionName = nameof(t);
            String s = JsonSerializer.Serialize(t);
            context.Session.SetString(sessionName, s);
        }
    
        public static void Clear<T>(T t, HttpContext context)
        {
            context.Session.Remove(nameof(t))   ;
        }
    }
}