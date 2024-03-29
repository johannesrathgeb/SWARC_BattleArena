﻿using BattleArena.Items;
using BattleArena.Items.OldVersion;
using BattleArena.Pawn;
using System;

namespace BattleArena
{
    class Program
    {
        //TODO
        //Weapon switch, zweite action
        //Singleton loggen
        //Observer
        static void Main(string[] args)
        {
            LoggingSystem logsys = LoggingSystem.getInstance();
            UserIO userinteraction = new UserIO();

            Random randomNumberGenerator = new Random();
            Hero[] playerList = { new Hero("Player 1", new LatharSwordAdapter(randomNumberGenerator)),
                new Hero("Player 2", new CynradBow(randomNumberGenerator)) };

            bool run = true;

            while (run)
            {
                userinteraction.ClearScreen();
                userinteraction.PrintPlayerInformation(playerList);

                foreach (Hero currentHero in playerList)
                {

                    bool action = false;
                    do
                    {
                        int userinput = -1;
                        do
                        {
                            userinteraction.PrintFightMenu(currentHero.Name);
                            userinput = userinteraction.GetUserIput();
                        } while (userinput < 0 || userinput > 6);

                        switch (userinput)
                        {
                            case 0:
                                // exit game
                                run = false;
                                userinteraction.ExitGame();
                                logsys.saveToFile();
                                return ;
                            case 1:
                                if (currentHero.Name == "Player 1")
                                {
                                    action = currentHero.Action(playerList[1]);
                                }
                                else
                                {
                                    action = currentHero.Action(playerList[0]);
                                }
                                break;
                            case 2:
                                action = currentHero.AddLeprechaun();
                                break;
                            case 3:
                                action = currentHero.AddTinyGoblin(randomNumberGenerator);
                                break;
                            case 4:
                                action = currentHero.AddMediumGoblin(randomNumberGenerator);
                                break;
                            case 5:
                                action = currentHero.AddBigGoblin(randomNumberGenerator);
                                break;
                            case 6:
                                if(currentHero.weaponName == "Cynrad Bow")
                                {
                                    action = currentHero.switchWeapon(new LatharSwordAdapter(randomNumberGenerator));
                                }
                                else
                                {
                                    action = currentHero.switchWeapon(new CynradBow(randomNumberGenerator));
                                }
                                break;
                            default:
                                break;
                        }

                        if (!action)
                        {
                            userinteraction.ClearScreen();
                            userinteraction.PrintPlayerInformation(playerList);
                            Console.WriteLine("\nNot enought money");
                        }
                    } while (!action);

                    currentHero.UpdateCoins();

                    if (currentHero.Name == "Player 1")
                    {
                        currentHero.useGoblins(playerList[1]);
                    }
                    else
                    {
                        currentHero.useGoblins(playerList[0]);
                    }
                }

                // end condition
                if (playerList[0].Health <= 0)
                {
                    userinteraction.EndGame(playerList[0].Name);
                    run = false;
                }
                else if (playerList[1].Health <= 0)
                {
                    userinteraction.EndGame(playerList[1].Name);
                    run = false;
                }
            }
            logsys.saveToFile();
        }
    }
}
