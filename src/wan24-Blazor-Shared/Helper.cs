using System.Collections.Frozen;
using System.Net.Mail;
using System.Security.Cryptography;

namespace wan24.Blazor
{
    /// <summary>
    /// Helper
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Alphabet
        /// </summary>
        public static readonly FrozenSet<char> Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToFrozenSet();

        /// <summary>
        /// Cloak a credit card number (show only the first and the last number block)
        /// </summary>
        /// <param name="cc">Credit card number</param>
        /// <returns>Cloaked credit card number</returns>
        public static string CloakCreditCardNumber(string cc)
        {
            cc = cc.Trim().Replace(" ", string.Empty);
            if (cc.Length < 8) throw new ArgumentOutOfRangeException(nameof(cc));
            return $"{cc[0..4]}********{cc[^4..]}";
        }

        /// <summary>
        /// Cloak a phone number (show only the first 4 and the last 2 digits)
        /// </summary>
        /// <param name="phone">Phone number</param>
        /// <returns>Cloaked phone number</returns>
        public static string CloakPhoneNumber(string phone)
        {
            phone = phone.Trim().Replace(" ", string.Empty);
            if (phone.Length < 6) throw new ArgumentOutOfRangeException(nameof(phone));
            return $"{phone[0..4]}***{phone[^2..]}";
        }

        /// <summary>
        /// Cloak an email address (show only a part of the alias and domain)
        /// </summary>
        /// <param name="email">Email address</param>
        /// <returns>Cloaked email address</returns>
        public static string CloakEmailAddress(string email)
        {
            email = email.Trim().Replace(" ", string.Empty);
            if (!email.Contains('@') || !MailAddress.TryCreate(email, out _)) throw new ArgumentException("Invalid email address", nameof(email));
            string[] parts = email.Split('@', 2),
                domainParts = parts[1].Split('.');
            if (domainParts.Length < 2) throw new ArgumentException("Invalid email address", nameof(email));
            string domain = string.Join('.', domainParts.SkipLast(1)),
                tld = domainParts[^1],
                alias = parts[0].Length > 1 ? $"{parts[0]}*{parts[^1]}" : $"{parts[0]}*";
            domain = domain.Length > 1 ? $"{domain[0]}*{domain[^1]}" : $"{domain}*";
            return $"{alias}@{domain}.{tld}";
        }

        /// <summary>
        /// Create a unique element ID
        /// </summary>
        /// <returns>Element ID</returns>
        public static string CreateElementId()
            => $"{new string([.. Enumerable.Range(0, 10).Select(i => Alphabet.Items.AsSpan()[RandomNumberGenerator.GetInt32(0, Alphabet.Count)])])}{DateTime.Now.Ticks}";

        /// <summary>
        /// Create a unique section ID, if a condition is <see langword="true"/>
        /// </summary>
        /// <param name="condition">Condition</param>
        /// <returns>Section ID or <see langword="null"/>, if the <c>condition</c> was <see langword="false"/></returns>
        public static string? CreateSectionId(in bool condition = true) => condition ? CreateElementId() : null;
    }
}
