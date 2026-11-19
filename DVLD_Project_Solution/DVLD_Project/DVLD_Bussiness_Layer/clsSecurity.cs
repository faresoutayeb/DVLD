using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CredentialManagement;

namespace DVLD_Bussiness_Layer
{
    static public  class clsSecurity
    {
        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static string symetricEncrypt(string plainText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);

                /*
                Here, you are setting the IV of the AES algorithm to a block of bytes 
                with a size equal to the block size of the algorithm divided by 8.
                The block size of AES is typically 128 bits (16 bytes),
                so the IV size is 128 bits / 8 = 16 bytes.
                 */

                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string symetricDecrypt(string cipherText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }

        public static string AsymetricEncrypt(string plainText, string publicKey)
        {
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(publicKey);

                    byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(plainText), false);
                    return Convert.ToBase64String(encryptedData);
                }
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"Encryption error: {ex.Message}");
                throw; // Rethrow the exception to be caught in the Main method
            }
        }

        public static string AsymetricDecrypt(string cipherText, string privateKey)
        {
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);

                    byte[] encryptedData = Convert.FromBase64String(cipherText);
                    byte[] decryptedData = rsa.Decrypt(encryptedData, false);

                    return Encoding.UTF8.GetString(decryptedData);
                }
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"Decryption error: {ex.Message}");
                throw; // Rethrow the exception to be caught in the Main method
            }
        }


        public static event Action<string> OnRememberMeIssue;
        public static void RememberMeIssue(string ErrorMessage)
        {
            OnRememberMeIssue?.Invoke(ErrorMessage);
        }

        public static event Action<string> OnIssueGettingStoredCredentials;
        //----------------------------------------------------------------------------------------
        public static void IssueGettingStoredCredentials(string ErrorMessage)
        {
            OnIssueGettingStoredCredentials?.Invoke(ErrorMessage);
        }


        public static bool RememberUsernameAndPasswordInRegistry(string UserName, string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_LastLoggedInfo";


            string UserNameKey = "DVLD-Last-Login-UserName";
            string PasswordKey = "DVLD-Last-Login-Password";

            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, UserNameKey, UserName, RegistryValueKind.String);
                Registry.SetValue(keyPath, PasswordKey, Password, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }


        }

        public static bool RememberUsernameAndPasswordInTextFile(string Username, string Password)
        {

            try
            {
                //this will get the current project directory folder.
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();


                // Define the path to the text file where you want to save the data
                string filePath = currentDirectory + "\\data.txt";

                //incase the username is empty, delete the file
                if ((Username == "" || Password == "") && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;

                }

                // concatonate username and passwrod withe seperator.
                string dataToSave = Username + "#//#" + Password;

                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the data to the file
                    writer.WriteLine(dataToSave);

                    return true;
                }
            }
            catch (Exception ex)
            {
                if (OnRememberMeIssue != null)
                {
                    RememberMeIssue(ex.ToString());

                }
                return false;
            }

        }

        public static bool GetStoredCredentialFromTextFile(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                string filePath = currentDirectory + "\\data.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (OnIssueGettingStoredCredentials != null)
                {
                    IssueGettingStoredCredentials(ex.ToString());

                }

                return false;
            }

        }

        public static bool GetStoredCredentialFromRegistry(ref string Username, ref string Password)
        {

            // string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\DVLD-Last-Login-Credential";
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD-Last-Login-Credential";

            string UserNameKey = "DVLD-Last-Login-UserName";
            string PasswordKey = "DVLD-Last-Login-Password";


            try
            {

                // Write the value to the Registry
                string UsernameValue = Registry.GetValue(keyPath, UserNameKey, null) as string;
                string PasswordValue = Registry.GetValue(keyPath, PasswordKey, null) as string;

                Username = (UsernameValue != null) ? UsernameValue : "";

                Password = (PasswordValue != null) ? PasswordValue : "";


                Console.WriteLine($"Login Successfully for user {Username} at {DateTime.Now}");

                return true;
            }
            catch (Exception ex)
            {
                if (OnIssueGettingStoredCredentials != null)
                {
                    IssueGettingStoredCredentials(ex.ToString());

                }

                return false;
            }

        }
        public static bool CompareBytes(byte[] First, byte[] Second)
        {
            return First.SequenceEqual(Second);
        }

        public static bool BackupLastLoginCredentialFromRegistry()
        {
            string UserName = "";
            string Password = "";

            GetStoredCredentialFromRegistry(ref UserName, ref Password);

            if (UserName == "" && Password == "")
                return false;

            //string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\DVLD-Backup-Previous-Login-Credential";
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD-Backup-Previous-Login-Credential";

            string UserNameKey = "DVLD-Previous-Login-UserName";
            string PasswordKey = "DVLD-Previous-Login-Password";


            try
            {

                // Write the value to the Registry
                Registry.SetValue(keyPath, UserNameKey, UserName, RegistryValueKind.String);
                Registry.SetValue(keyPath, PasswordKey, Password, RegistryValueKind.String);


                Console.WriteLine($"Login Successfully for user {UserName} at {DateTime.Now}");

                return true;
            }
            catch (Exception ex)
            {
          
                    IssueGettingStoredCredentials(ex.ToString());

                

                return false;
            }



        }
         
        
        private const string Target = "DVLD_Presentation_Layer";

        public static void RememberUsernameAndPasswordInWindowsCredentialManager(string UserName, string Password)
        {
            try
            {
                using (var credential = new Credential())
                {
                    credential.Target = Target;
                    credential.Username = UserName;
                    credential.Password = Password;
                    credential.Type = CredentialType.Generic;
                    credential.PersistanceType = PersistanceType.LocalComputer;
                    credential.Save();
                    
                }
            }
            catch (Exception ex)
            {

                RememberMeIssue(ex.ToString());
            }


        }
        public static (string Username, string Password) GetStoredCredentialFromRegistryWindowsCredentialManager()
        {


            try
            {
                using (var credential = new Credential())
                {
                    credential.Target = Target;

                    if (credential.Load())
                        return (credential.Username, credential.Password);

                }

            }
            catch (Exception ex)
            {
               IssueGettingStoredCredentials(ex.ToString());
            }
            return (null, null);

        }



        public static string HashPassword(string Password, out string Salt)
        {
            byte[] SaltBytes = new byte[16];

            using (var RNG = RandomNumberGenerator.Create())
                RNG.GetBytes(SaltBytes);

            Salt = Convert.ToBase64String(SaltBytes);

            return HashPassword(Password, SaltBytes);
        }

        private static string HashPassword(string Password, byte[] SaltBytes)
        {
            using (var PBKDF2 = new Rfc2898DeriveBytes(  Password, SaltBytes, 10000, HashAlgorithmName.SHA256))
            {
                return Convert.ToBase64String(PBKDF2.GetBytes(32));
            }
            
        }

        public static bool VerifyPassword(string Password, string StoredHash, string StoredSalt)
        {
            byte[] SaltBytes = Convert.FromBase64String(StoredSalt);

            string NewHash = HashPassword(Password, SaltBytes);

            return NewHash == StoredHash;
        }


    }
}
