namespace SBC.Common.Extensions
{
    using System.Linq;

    public static class StringExtensions
    {
        public static (string FirstName, string LastName) GetNames(
            this string fullName)
        {
            var fullNameArgsBySpace = fullName.Split(' ');
            var fullNameArgs = fullNameArgsBySpace.Where(n => !string.IsNullOrWhiteSpace(n.ToString()));
            var fullNameText = string.Join(" ", fullNameArgs);
            var fullNameArray = fullNameText.Split(' ', 2);

            var firstName = fullNameArray.First().ToLower();
            var lastName = fullNameArray.Last().ToLower();

            return (firstName, lastName);
        }
    }
}
