/*

Project by Koal Casler
14/10/23

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPSystem
{
    internal class Program
    {
        static int Health;
        static string HealthStatus;
        static int Shield;
        static int Lives;
        static int Level;
        static int EXP;
        static string StarLine;

        static void Main(string[] args)
        {
            // The Game!
            StartUp();
            ShowHUD();
            Next();
            TakeDamage(50);
            IncreaseEXP(110);
            ShowHUD();
            Next();
            TakeDamage(-10);
            IncreaseEXP(-110);
            ShowHUD();
            Next();
            TakeDamage(100);
            IncreaseEXP(210);
            ShowHUD();
            Next();
            ShowHUD();
            Next();
            Heal(50);
            RegenerateShield(50);
            ShowHUD();
            Next();
            Heal(-10);
            RegenerateShield(-10);
            ShowHUD();
            Next();
            TakeDamage(100); 
            ShowHUD();
            Next();
            TakeDamage(300);
            ShowHUD();
            Next();
            TakeDamage(175);
            ShowHUD();
            Next();
            TakeDamage(175);
            ShowHUD();
            Next();
            TakeDamage(175);
            ShowHUD();
            Next();
            TakeDamage(175);
            ShowHUD();
            Next();


        }
        static void StartUp()
        {
            //Sets base Values
            EXP = 0;
            Level = 1;
            Health = 100;
            Shield = 100;
            Lives = 3;
            StarLine = "*******************************************";
        }
        static void ShowHUD()
        {
            //Displays HUD in Console
            HealthString();
            Console.WriteLine(StarLine);
            Console.WriteLine(string.Format("Your health is at {0}%", Health));
            Console.WriteLine(string.Format("Your heath status is: {0}", HealthStatus));
            Console.WriteLine(string.Format("Your Shield is at {0}%", Shield));
            Console.WriteLine(string.Format("You have {0} Lives remaining.", Lives));
            Console.WriteLine(string.Format("You are level {0}!", Level));
            Console.WriteLine(string.Format("Your EXP: {0}", EXP));
            Console.WriteLine(StarLine);
        }
        static void Next()
        {
            // Sets up the next test
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void TakeDamage(int Damage)
        {
            // Does damage with shield overflow
            if (Damage <= 0)
            {
                Console.WriteLine("Damage Cannot Be 0 or less.");
                ShowHUD();
                return;
            }
            else
            {
                Console.WriteLine(string.Format("You took {0} Damage!", Damage));
                if(Shield > 0)
                {
                    Shield -= Damage;
                    if(Shield < 0)
                    {
                        Health += Shield;
                        Shield = 0;
                    }
                }
                else
                {
                    Shield = 0;
                    Health -= Damage;
                }
                if(Health <= 0)
                {
                    Health = 0;
                    ShowHUD();
                    Revive();
                }   
            }
        }
        static void Heal(int HpGain)
        {
            // Heals the player
            if(HpGain <= 0)
            {
                Console.WriteLine("You cannot heal 0 or a Negative.");
                return;
            }
            Health += HpGain;
            Console.WriteLine(string.Format("You gained {0} Hp!", HpGain));
            if(Health > 100)
            {
                Health = 100;
            }
        }
        static void RegenerateShield(int ShieldGain)
        {
            // Regenerates Shield for player
            if(ShieldGain <= 0)
            {
                Console.WriteLine("You cannot regen 0 or a Negative.");
                return;
            }
            Shield += ShieldGain;
            Console.WriteLine(string.Format("You Regained {0} Shield!", ShieldGain));
            if(Shield > 100)
            {
                Shield = 100;
            }
        }
        static void Revive()
        {
            // Revives player
            Health = 100;
            Shield = 100;
            Lives -= 1;
            if(Lives <= 0)
            {
                Console.WriteLine("You have lost, press any key to exit.");
                Health = 0;
                Shield = 0;
                ShowHUD();
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        static void IncreaseEXP(int EXPGain)
        {
            // Increases EXP and level 
            if(EXPGain <= 0)
            {
                Console.WriteLine("You cannot lose EXP...");
                return;
            }
            EXP += EXPGain;
            Console.WriteLine(string.Format("You gained {0} EXP!", EXPGain));
            if(EXP >= (Level * 100) && EXP < (Level * 200))
            {
                Level += 1;
            }
        } 
        static void HealthString()
        {
            // Sets health status string
            if(Health == 100)
            {
                HealthStatus = "Perfect!";
            }
            if(Health < 100 && Health >= 75)
            {
                HealthStatus = "Healthy";
            }
            if(Health < 75 && Health >= 50)
            {
                HealthStatus = "Hurt";
            }
            if(Health < 50 && Health >= 25)
            {
                HealthStatus = "Badly Hurt";
            }
            if(Health < 25 && Health >= 1)
            {
                HealthStatus = "Critical!";
            }
            if(Health <= 0)
            {
                HealthStatus = "Dead!";
            }
        }
    }
}
