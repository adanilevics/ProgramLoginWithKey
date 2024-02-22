using System;
using System.Security.Cryptography;
using System.Text;


// Set the time zone
using System.Text;

TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("UTC");

// Get the current date in the specified time zone
DateTime currentDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow.Date, timeZone);

// Convert the date to a string
string dateString = currentDate.ToString("yyyy-MM-dd");

// Hash the string using SHA256
byte[] hashBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(dateString));

// Truncate the hash to 64 bits (8 bytes)
byte[] truncatedHash = new byte[8];
Array.Copy(hashBytes, truncatedHash, 8);

// Convert the truncated hash to a string in hexadecimal format
string hashString = BitConverter.ToString(truncatedHash).Replace("-", "");

Console.Write($" {dateString}\n{hashString} \n");

System.Threading.Thread.Sleep(500000000);
