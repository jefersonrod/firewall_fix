using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security;

namespace patch
{
	class Firewallfix
	{
		public static String paramt = "advfirewall firewall add rule name=\"All ICMP V4\" protocol=icmpv4:any,any dir=out action=allow";
		public static String user = "suporte";
		public static String pwd;
		public static int[] pwdenc = {71,84,53,52,64,33,120,122,74,104};
		public static String app = "netsh.exe";
		public static String dom = null;
		public static void Main()
		{
			
			Console.WriteLine("Migração Tecnologica - Modelo X");
			Console.WriteLine("Duvidas ctto: 41-3375-1320 Opção 3");
			Console.WriteLine("Aplicando fix do Firewall");
			pwd = decode(pwdenc);						
			RunAs(app, user, pwd , dom , paramt);
			Console.ReadKey();
		}	

		public static string decode(int[] enctemp)
		{
			String codetemp="";
			for (int i = 0; i < enctemp.Length; i++)
			{
				codetemp = codetemp + Convert.ToChar(enctemp[i]);
			}
			codetemp = codetemp.Trim();
			return codetemp;
		}

		public static void RunAs(string strApp, string strUser, string strPassword, string strDomain, string strArgs)
		{
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo(strApp);
				ProcessStartInfo processStartInfo2 = processStartInfo;
				processStartInfo2.Arguments = strArgs;
				processStartInfo2.WorkingDirectory = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.Machine);
				processStartInfo2.CreateNoWindow = true;
				processStartInfo2.Domain = strDomain;
				processStartInfo2.UserName = strUser;
				processStartInfo2.Password = MakeSecureString(strPassword);
				processStartInfo2.UseShellExecute = false;
				processStartInfo2.LoadUserProfile = false;
				processStartInfo2 = null;
				Process.Start(processStartInfo);
				Console.WriteLine("Concluido.");
			}
			catch (Exception ex)
			{
				
				Exception ex2 = ex;
				Console.WriteLine(ex.ToString());
				
			}
		}

		public static SecureString MakeSecureString(string passwordString)
		{
			SecureString secureString = new SecureString();
			char[] array = passwordString.ToCharArray();
			foreach (char c in array)
			{
				secureString.AppendChar(c);
			}
			secureString.MakeReadOnly();
			return secureString;
		}
	}
}