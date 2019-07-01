using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Supreme_Mobile.Models;

namespace Supreme_Mobile.Managers
{
    public class TokenValidation
    {
        public bool Validated { get { return Errors.Count == 0; } }
        public readonly List<TokenValidationStatus> Errors = new List<TokenValidationStatus>();
    }

    public enum TokenValidationStatus
    {
        Expired,
        WrongUser,
        WrongPurpose,
        WrongGuid
    }

    public static class TokenManager
    {
        public static string GenerateToken(string reason, MyUsersModel user)
        {
            byte[] _time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] _key = Guid.Parse(user.SecurityStamp).ToByteArray();
            byte[] _Id = Encoding.UTF8.GetBytes(user.UserID.ToString());
            byte[] _reason = Encoding.UTF8.GetBytes(reason);
            byte[] data = new byte[_time.Length + _key.Length + _reason.Length + _Id.Length];

            System.Buffer.BlockCopy(_time, 0, data, 0, _time.Length);
            System.Buffer.BlockCopy(_key, 0, data, _time.Length, _key.Length);
            System.Buffer.BlockCopy(_reason, 0, data, _time.Length + _key.Length, _reason.Length);
            System.Buffer.BlockCopy(_Id, 0, data, _time.Length + _key.Length + _reason.Length, _Id.Length);

            return Convert.ToBase64String(data.ToArray());
        }

        public static TokenValidation ValidateToken(string reason, MyUsersModel user, string token)
        {
            var result = new TokenValidation();
            byte[] data = Convert.FromBase64String(token);
            byte[] _time = data.Take(8).ToArray();
            byte[] _key = data.Skip(8).Take(16).ToArray();
            byte[] _reason = data.Skip(24).Take(2).ToArray();
            byte[] _Id = data.Skip(26).ToArray();

            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(_time, 0));
            if (when < DateTime.UtcNow.AddHours(-24))
            {
                result.Errors.Add(TokenValidationStatus.Expired);
            }

            Guid gKey = new Guid(_key);
            if (gKey.ToString() != user.SecurityStamp)
            {
                result.Errors.Add(TokenValidationStatus.WrongGuid);
            }

            if (reason != Encoding.UTF8.GetString(_reason))
            {
                result.Errors.Add(TokenValidationStatus.WrongPurpose);
            }

            if (user.UserID.ToString() != Encoding.UTF8.GetString(_Id))
            {
                result.Errors.Add(TokenValidationStatus.WrongUser);
            }

            return result;
        }

        public static string GetValidOperatorID(string reason, string token)
        {
            var result = new TokenValidation();
            byte[] data = Convert.FromBase64String(token);
            byte[] _Id = data.Skip(26).ToArray();
            
            return Encoding.UTF8.GetString(_Id);
        }

    }
}