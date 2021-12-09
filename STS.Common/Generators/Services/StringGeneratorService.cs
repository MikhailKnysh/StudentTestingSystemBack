using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using FluentResults;

namespace STS.Common.Generators.Services
{
    public class StringGeneratorService : IStringGeneratorService
    {
        private readonly int _defoultLengthPassword = 8;
        private readonly string _alphanumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public Result<string> GeneratePassword()
        {
            var passwordResult = GetRandomString(_defoultLengthPassword, _alphanumericCharacters);

            return passwordResult;
        }

        public Result<string> GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length > 0 && length < int.MaxValue / 8 && characterSet != null)
            {
                var characterArray = characterSet.Distinct().ToArray();

                if (characterArray.Length != 0)
                {
                    var bytes = new byte[length * 8];
                    new RNGCryptoServiceProvider().GetBytes(bytes);
                    var resultStr = new char[length];

                    for (int i = 0; i < length; i++)
                    {
                        ulong value = BitConverter.ToUInt64(bytes, i * 8);
                        resultStr[i] = characterArray[value % (uint)characterArray.Length];
                    }

                    var result = Result.Ok<string>(new string(resultStr));

                    return result;
                }

                return Result.Fail("Empty characterSet");
            }

            return Result.Fail("Invalid length or characterSet is null");
        }
    }
}