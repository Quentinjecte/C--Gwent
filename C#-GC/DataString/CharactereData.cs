﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC.DataString
{
    internal class CharactereData
    {
        public static string Prompt = @"
                                                                                                           ░▒▓██▓▒░         
      ░▒▓██████▓▒░  ░▒▓█▓▒░         ░▒▓██████▓▒░   ░▒▓███████▓▒░ ░▒▓████████▓▒░ ░▒▓███████▓▒░          ░▒▓██████████▓▒░         ░▒▓████████▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓████████▓▒░  ░▒▓███████▓▒░ 
     ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░     ░▒▓█▓▒░          ░▒▓█▓▒░     ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        
     ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░   ░▒▓█▓▒░     ░▒▒░     ░▒▓█▓▒░   ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░        
     ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░  ░▒▓██████▓▒░  ░▒▓██████▓▒░   ░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒░     ░▓██▓░     ░▒▓█▓▒░  ░▒▓██████▓▒░    ░▒▓██████▓▒░  ░▒▓██████▓▒░    ░▒▓██████▓▒░  
     ░▒▓█▓▒░        ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░        ░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░   ░▒▓█▓▒░     ░▒▒░     ░▒▓█▓▒░   ░▒▓█▓▒░           ░▒▓█▓▒░     ░▒▓█▓▒░               ░▒▓█▓▒░ 
     ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░        ░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░     ░▒▓█▓▒░          ░▒▓█▓▒░     ░▒▓█▓▒░           ░▒▓█▓▒░     ░▒▓█▓▒░               ░▒▓█▓▒░ 
      ░▒▓██████▓▒░  ░▒▓████████▓▒░  ░▒▓██████▓▒░  ░▒▓███████▓▒░  ░▒▓████████▓▒░ ░▒▓███████▓▒░           ░▒▓█████████▓▒░         ░▒▓████████▓▒░    ░▒▓█▓▒░     ░▒▓████████▓▒░ ░▒▓███████▓▒░  
                                                                                                           ░▒▓██▓▒░
Use arrow keys and press 'Spacebar' to select ur options :
";

        public static string[] HubInfo =
        {@"
     ███▄    █ ▓█████  █     █░     ▄████  ▄▄▄       ███▄ ▄███▓▓█████ 
     ██ ▀█   █ ▓█   ▀ ▓█░ █ ░█░    ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀ 
    ▓██  ▀█ ██▒▒███   ▒█░ █ ░█    ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███   
    ▓██▒  ▐▌██▒▒▓█  ▄ ░█░ █ ░█    ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄ 
    ▒██░   ▓██░░▒████▒░░██▒██▓    ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒
    ", @"
     ▄████▄   ▒█████   ███▄    █ ▄▄▄█████▓ ██▓ ███▄    █  █    ██ ▓█████ 
    ▒██▀ ▀█  ▒██▒  ██▒ ██ ▀█   █ ▓  ██▒ ▓▒▓██▒ ██ ▀█   █  ██  ▓██▒▓█   ▀ 
    ▒▓█    ▄ ▒██░  ██▒▓██  ▀█ ██▒▒ ▓██░ ▒░▒██▒▓██  ▀█ ██▒▓██  ▒██░▒███   
    ▒▓▓▄ ▄██▒▒██   ██░▓██▒  ▐▌██▒░ ▓██▓ ░ ░██░▓██▒  ▐▌██▒▓▓█  ░██░▒▓█  ▄ 
    ▒ ▓███▀ ░░ ████▓▒░▒██░   ▓██░  ▒██▒ ░ ░██░▒██░   ▓██░▒▒█████▓ ░▒████▒
    ",@"
     ▒█████   ██▓███  ▄▄▄█████▓ ██▓ ▒█████   ███▄    █   ██████ 
    ▒██▒  ██▒▓██░  ██▒▓  ██▒ ▓▒▓██▒▒██▒  ██▒ ██ ▀█   █ ▒██    ▒ 
    ▒██░  ██▒▓██░ ██▓▒▒ ▓██░ ▒░▒██▒▒██░  ██▒▓██  ▀█ ██▒░ ▓██▄   
    ▒██   ██░▒██▄█▓▒ ▒░ ▓██▓ ░ ░██░▒██   ██░▓██▒  ▐▌██▒  ▒   ██▒
    ░ ████▓▒░▒██▒ ░  ░  ▒██▒ ░ ░██░░ ████▓▒░▒██░   ▓██░▒██████▒▒
    ", @"
     ▄████▄   ██▀███  ▓█████ ▓█████▄  ██▓▄▄▄█████▓  ██████ 
    ▒██▀ ▀█  ▓██ ▒ ██▒▓█   ▀ ▒██▀ ██▌▓██▒▓  ██▒ ▓▒▒██    ▒ 
    ▒▓█    ▄ ▓██ ░▄█ ▒▒███   ░██   █▌▒██▒▒ ▓██░ ▒░░ ▓██▄   
    ▒▓▓▄ ▄██▒▒██▀▀█▄  ▒▓█  ▄ ░▓█▄   ▌░██░░ ▓██▓ ░   ▒   ██▒
    ▒ ▓███▀ ░░██▓ ▒██▒░▒████▒░▒████▓ ░██░  ▒██▒ ░ ▒██████▒▒
    ", @"
    ▓█████ ▒██   ██▒ ██▓▄▄▄█████▓
    ▓█   ▀ ▒▒ █ █ ▒░▓██▒▓  ██▒ ▓▒
    ▒███   ░░  █   ░▒██▒▒ ▓██░ ▒░
    ▒▓█  ▄  ░ █ █ ▒ ░██░░ ▓██▓ ░ 
    ░▒████▒▒██▒ ▒██▒░██░  ▒██▒ ░ 
    "
        };

        public static string[] OptionInfo =
                            { @"
     █     █░ ██▓ ███▄    █ ▓█████▄  ▒█████   █     █░     ██████  ██▓▒███████▒▓█████ 
    ▓█░ █ ░█░▓██▒ ██ ▀█   █ ▒██▀ ██▌▒██▒  ██▒▓█░ █ ░█░   ▒██    ▒ ▓██▒▒ ▒ ▒ ▄▀░▓█   ▀ 
    ▒█░ █ ░█ ▒██▒▓██  ▀█ ██▒░██   █▌▒██░  ██▒▒█░ █ ░█    ░ ▓██▄   ▒██▒░ ▒ ▄▀▒░ ▒███   
    ░█░ █ ░█ ░██░▓██▒  ▐▌██▒░▓█▄   ▌▒██   ██░░█░ █ ░█      ▒   ██▒░██░  ▄▀▒   ░▒▓█  ▄ 
    ░░██▒██▓ ░██░▒██░   ▓██░░▒████▓ ░ ████▓▒░░░██▒██▓    ▒██████▒▒░██░▒███████▒░▒████▒", @"

     ██▓     ▄▄▄       ███▄    █   ▄████  █    ██  ▄▄▄        ▄████ ▓█████ 
    ▓██▒    ▒████▄     ██ ▀█   █  ██▒ ▀█▒ ██  ▓██▒▒████▄     ██▒ ▀█▒▓█   ▀ 
    ▒██░    ▒██  ▀█▄  ▓██  ▀█ ██▒▒██░▄▄▄░▓██  ▒██░▒██  ▀█▄  ▒██░▄▄▄░▒███   
    ▒██░    ░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█  ██▓▓▓█  ░██░░██▄▄▄▄██ ░▓█  ██▓▒▓█  ▄ 
    ░██████▒ ▓█   ▓██▒▒██░   ▓██░░▒▓███▀▒▒▒█████▓  ▓█   ▓██▒░▒▓███▀▒░▒████▒", @"

       ██████  ▒█████   █    ██  ███▄    █ ▓█████▄ 
     ▒██    ▒ ▒██▒  ██▒ ██  ▓██▒ ██ ▀█   █ ▒██▀ ██▌
     ░ ▓██▄   ▒██░  ██▒▓██  ▒██░▓██  ▀█ ██▒░██   █▌
       ▒   ██▒▒██   ██░▓▓█  ░██░▓██▒  ▐▌██▒░▓█▄   ▌
     ▒██████▒▒░ ████▓▒░▒▒█████▓ ▒██░   ▓██░░▒████▓  ", @"

    ▓█████ ▒██   ██▒ ██▓▄▄▄█████▓
    ▓█   ▀ ▒▒ █ █ ▒░▓██▒▓  ██▒ ▓▒
    ▒███   ░░  █   ░▒██▒▒ ▓██░ ▒░
    ▒▓█  ▄  ░ █ █ ▒ ░██░░ ▓██▓ ░ 
    ░▒████▒▒██▒ ▒██▒░██░  ▒██▒ ░ "
            };

        public static string[] OptionWindowSize =
                            { @"
      █████▒█    ██  ██▓     ██▓      ██████  ▄████▄   ██▀███  ▓█████ ▓█████  ███▄    █ 
    ▓██   ▒ ██  ▓██▒▓██▒    ▓██▒    ▒██    ▒ ▒██▀ ▀█  ▓██ ▒ ██▒▓█   ▀ ▓█   ▀  ██ ▀█   █ 
    ▒████ ░▓██  ▒██░▒██░    ▒██░    ░ ▓██▄   ▒▓█    ▄ ▓██ ░▄█ ▒▒███   ▒███   ▓██  ▀█ ██▒
    ░▓█▒  ░▓▓█  ░██░▒██░    ▒██░      ▒   ██▒▒▓▓▄ ▄██▒▒██▀▀█▄  ▒▓█  ▄ ▒▓█  ▄ ▓██▒  ▐▌██▒
    ░▒█░   ▒▒█████▓ ░██████▒░██████▒▒██████▒▒▒ ▓███▀ ░░██▓ ▒██▒░▒████▒░▒████▒▒██░   ▓██░
    ", @"
     ██  ██████   ██████   ██████  ██   ██ ▓██ ██████  ▓██████  ▓██████  
    ███ ██▒▒▓▓   ██▓ ████ ██▓ ████▓▓██ ██ ▓███   ▒▓▓██ ██▓▓████▓██  ████ 
    ▒██ ███████▒▒██▓██ ██ ██▓██ ██▒  ███▓  ▓██  █████▒▓██ ██ ██▓██ ██▒██ 
     ██ ██    ██ ████ ▓██ ████▓ ██ ▒██▓██   ██ ██▓▓  ▒▓████▓ ██▓████▒▒██ 
     ██▒▒██████▒ ▓██████▒ ▒██████▒▒██   ██▒▒██ ███████░░██████▓ ▒██████░ 
                                                                      ", @"
     ██ ██████   █████   ██████  ██   ██  ██  ██████  ██████  ██   ██ 
    ███      ██ ██   ██ ██  ████  ██ ██  ███ ██  ████      ██ ██   ██ 
     ██  █████   █████  ██ ██ ██   ███    ██ ██ ██ ██  █████  ███████ 
     ██ ██      ██   ██ ████  ██  ██ ██   ██ ████  ██ ██           ██ 
     ██ ███████  █████   ██████  ██   ██  ██  ██████  ███████      █"
            };

        public static string OverlayMenu =
                             @"████████████████████"+
                             @"██                ██" +
                             @"██                ██" +
                             @"██                ██" +
                             @"██                ██" +
                             @"██                ██" +
                             @"██                ██" +
                             @"██                ██" +
                             @"█                  █" +
                             @"█                  █"+
                             @"████████████████████";
        public static string OverlayFight =
@"████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████" +
@"██                                                                                                                                                        ██" +
@"██                                                                                                                                                        ██" +
@"██                                                                                                                                                        ██" +
@"██                                                                                                                                                        ██" +
@"██                                                                                                                                                        ██" +
@"████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████"
            ;

        public static string[] InfoDifficult =
                            { @"
    ▓█████ ▄▄▄        ██████▓██   ██▓
    ▓█   ▀▒████▄    ▒██    ▒ ▒██  ██▒
    ▒███  ▒██  ▀█▄  ░ ▓██▄    ▒██ ██░
    ▒▓█  ▄░██▄▄▄▄██   ▒   ██▒ ░ ▐██▓░
    ░▒████▒▓█   ▓██▒▒██████▒▒ ░ ██▒▓░
    ░░ ▒░ ░▒▒   ▓▒█░▒ ▒▓▒ ▒ ░  ██▒▒▒ ", @"

     ███▄ ▄███▓▓█████ ▓█████▄  ██▓ █    ██  ███▄ ▄███▓
    ▓██▒▀█▀ ██▒▓█   ▀ ▒██▀ ██▌▓██▒ ██  ▓██▒▓██▒▀█▀ ██▒
    ▓██    ▓██░▒███   ░██   █▌▒██▒▓██  ▒██░▓██    ▓██░
    ▒██    ▒██ ▒▓█  ▄ ░▓█▄   ▌░██░▓▓█  ░██░▒██    ▒██ 
    ▒██▒   ░██▒░▒████▒░▒████▓ ░██░▒▒█████▓ ▒██▒   ░██▒
    ░ ▒░   ░  ░░░ ▒░ ░ ▒▒▓  ▒ ░▓  ░▒▓▒ ▒ ▒ ░ ▒░   ░  ░", @"

     ██░ ██  ▄▄▄       ██▀███  ▓█████▄ 
    ▓██░ ██▒▒████▄    ▓██ ▒ ██▒▒██▀ ██▌
    ▒██▀▀██░▒██  ▀█▄  ▓██ ░▄█ ▒░██   █▌
    ░▓█ ░██ ░██▄▄▄▄██ ▒██▀▀█▄  ░▓█▄   ▌
    ░▓█▒░██▓ ▓█   ▓██▒░██▓ ▒██▒░▒████▓ 
     ▒ ░░▒░▒ ▒▒   ▓▒█░░ ▒▓ ░▒▓░ ▒▒▓  ▒",
            };

        public static string[] InfoHeroes =
                            { @"
  █████▒ ██▓  ▄████  ██░ ██ ▄▄▄█████▓▓█████  ██▀███  
▓██   ▒ ▓██▒ ██▒ ▀█▒▓██░ ██▒▓  ██▒ ▓▒▓█   ▀ ▓██ ▒ ██▒
▒████ ░ ▒██▒▒██░▄▄▄░▒██▀▀██░▒ ▓██░ ▒░▒███   ▓██ ░▄█ ▒
░▓█▒  ░ ░██░░▓█  ██▓░▓█ ░██ ░ ▓██▓ ░ ▒▓█  ▄ ▒██▀▀█▄  
░▒█░    ░██░░▒▓███▀▒░▓█▒░██▓  ▒██▒ ░ ░▒████▒░██▓ ▒██▒
 ▒ ░    ░▓   ░▒   ▒  ▒ ░░▒░▒  ▒ ░░   ░░ ▒░ ░░ ▒▓ ░▒▓░", @"

 ▄████▄   ██▀███   █    ██   ██████  ▄▄▄      ▓█████▄ ▓█████  ██▀███  
▒██▀ ▀█  ▓██ ▒ ██▒ ██  ▓██▒▒██    ▒ ▒████▄    ▒██▀ ██▌▓█   ▀ ▓██ ▒ ██▒
▒▓█    ▄ ▓██ ░▄█ ▒▓██  ▒██░░ ▓██▄   ▒██  ▀█▄  ░██   █▌▒███   ▓██ ░▄█ ▒
▒▓▓▄ ▄██▒▒██▀▀█▄  ▓▓█  ░██░  ▒   ██▒░██▄▄▄▄██ ░▓█▄   ▌▒▓█  ▄ ▒██▀▀█▄  
▒ ▓███▀ ░░██▓ ▒██▒▒▒█████▓ ▒██████▒▒ ▓█   ▓██▒░▒████▓ ░▒████▒░██▓ ▒██▒
░ ░▒ ▒  ░░ ▒▓ ░▒▓░░▒▓▒ ▒ ▒ ▒ ▒▓▒ ▒ ░ ▒▒   ▓▒█░ ▒▒▓  ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░", 
            @"
 ██▓███   ██▀███   ██▓▓█████   ██████ ▄▄▄█████▓
▓██░  ██▒▓██ ▒ ██▒▓██▒▓█   ▀ ▒██    ▒ ▓  ██▒ ▓▒
▓██░ ██▓▒▓██ ░▄█ ▒▒██▒▒███   ░ ▓██▄   ▒ ▓██░ ▒░
▒██▄█▓▒ ▒▒██▀▀█▄  ░██░▒▓█  ▄   ▒   ██▒░ ▓██▓ ░ 
▒██▒ ░  ░░██▓ ▒██▒░██░░▒████▒▒██████▒▒  ▒██▒ ░ 
▒▓▒░ ░  ░░ ▒▓ ░▒▓░░▓  ░░ ▒░ ░▒ ▒▓▒ ▒ ░  ▒ ░░    ",
            @" 
 ▄▄▄       ██▀███   ▄████▄   ▄▄▄       ███▄    █  ██▓  ██████ ▄▄▄█████▓
▒████▄    ▓██ ▒ ██▒▒██▀ ▀█  ▒████▄     ██ ▀█   █ ▓██▒▒██    ▒ ▓  ██▒ ▓▒
▒██  ▀█▄  ▓██ ░▄█ ▒▒▓█    ▄ ▒██  ▀█▄  ▓██  ▀█ ██▒▒██▒░ ▓██▄   ▒ ▓██░ ▒░
░██▄▄▄▄██ ▒██▀▀█▄  ▒▓▓▄ ▄██▒░██▄▄▄▄██ ▓██▒  ▐▌██▒░██░  ▒   ██▒░ ▓██▓ ░ 
 ▓█   ▓██▒░██▓ ▒██▒▒ ▓███▀ ░ ▓█   ▓██▒▒██░   ▓██░░██░▒██████▒▒  ▒██▒ ░ 
 ▒▒   ▓▒█░░ ▒▓ ░▒▓░░ ░▒ ▒  ░ ▒▒   ▓▒█░░ ▒░   ▒ ▒ ░▓  ▒ ▒▓▒ ▒ ░  ▒ ░░   ",
            @"
 ██▀███   ▒█████    ▄████  █    ██ ▓█████ 
▓██ ▒ ██▒▒██▒  ██▒ ██▒ ▀█▒ ██  ▓██▒▓█   ▀ 
▓██ ░▄█ ▒▒██░  ██▒▒██░▄▄▄░▓██  ▒██░▒███   
▒██▀▀█▄  ▒██   ██░░▓█  ██▓▓▓█  ░██░▒▓█  ▄ 
░██▓ ▒██▒░ ████▓▒░░▒▓███▀▒▒▒█████▓ ░▒████▒
░ ▒▓ ░▒▓░░ ▒░▒░▒░  ░▒   ▒ ░▒▓▒ ▒ ▒ ░░ ▒░ ░",
        };

        public static string GameOver = @"
                                                                               ░▒▓██▓▒░
 ░▒▓██████▓▒░   ░▒▓██████▓▒░  ░▒▓██████████████▓▒░  ░▒▓████████▓▒░         ░▒▓██████████▓▒░            ░▒▓██████▓▒░  ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓████████▓▒░ ░▒▓███████▓▒░        
░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░            ░▒▓█▓▒░          ░▒▓█▓▒░       ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░       
░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░          ░▒▓█▓▒░     ░▒▒░     ░▒▓█▓▒░     ░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒▒▓█▓▒░  ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░       
░▒▓█▓▒▒▓███▓▒░ ░▒▓████████▓▒░ ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░ ░▒▓██████▓▒░    ░▒▓█▓▒░     ░▓██▓░     ░▒▓█▓▒░    ░▒▓█▓▒░░▒▓█▓▒░  ░▒▓█▓▒▒▓█▓▒░  ░▒▓██████▓▒░   ░▒▓███████▓▒░        
░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░          ░▒▓█▓▒░     ░▒▒░     ░▒▓█▓▒░     ░▒▓█▓▒░░▒▓█▓▒░   ░▒▓█▓▓█▓▒░   ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░       
░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░            ░▒▓█▓▒░          ░▒▓█▓▒░       ░▒▓█▓▒░░▒▓█▓▒░   ░▒▓█▓▓█▓▒░   ░▒▓█▓▒░        ░▒▓█▓▒░░▒▓█▓▒░       
 ░▒▓██████▓▒░  ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░░▒▓█▓▒░ ░▒▓████████▓▒░          ░▒▓█████████▓▒░            ░▒▓██████▓▒░     ░▒▓██▓▒░    ░▒▓████████▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ 
                                                                               ░▒▓██▓▒░               
";
    }
}

