using System.Text.RegularExpressions;

namespace Hugo.Mvc.Domain.Validation.Documentos
{
	public class EmailValidation
	{
		public static bool Validar(string email)
		{
			return System.Text.RegularExpressions.Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
		}
	}
}
