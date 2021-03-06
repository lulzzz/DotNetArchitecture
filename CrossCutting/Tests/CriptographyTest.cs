using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.Security;

namespace Solution.CrossCutting.Tests
{
	[TestClass]
	public class CriptographyTest
	{
		public CriptographyTest()
		{
			DependencyInjection.DependencyInjection.RegisterServices();
			Criptography = DependencyInjection.DependencyInjection.GetService<ICriptography>();
			Criptography.SetKey("8800A390DCF24C9087F8AAE870FCFE02");
		}

		ICriptography Criptography { get; }

		[TestMethod]
		public void Criptography_EncryptDecrypt()
		{
			var encrypted = Criptography.Encrypt(nameof(Criptography));
			var decrypted = Criptography.Decrypt(encrypted);
			Assert.AreEqual(nameof(Criptography), decrypted);
		}
	}
}
