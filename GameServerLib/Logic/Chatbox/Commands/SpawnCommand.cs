﻿using System;
using System.Collections.Generic;
using System.Numerics;
using ENet;
using LeagueSandbox.GameServer.Core.Logic;
using LeagueSandbox.GameServer.Logic.Enet;
using LeagueSandbox.GameServer.Logic.GameObjects;
using LeagueSandbox.GameServer.Logic.Players;

namespace LeagueSandbox.GameServer.Logic.Chatbox.Commands
{
    public class SpawnCommand : ChatCommandBase
    {
        private readonly Game _game;
        private readonly PlayerManager _playerManager;

        public override string Command => "spawn";
        public override string Syntax => $"{Command} minionsblue minionspurple";

        public SpawnCommand(ChatCommandManager chatCommandManager, Game game, PlayerManager playerManager)
            : base(chatCommandManager)
        {
            _game = game;
            _playerManager = playerManager;
        }

        public override void Execute(Peer peer, bool hasReceivedArguments, string arguments = "")
        {
            var split = arguments.ToLower().Split(' ');

            if (split.Length < 2)
            {
                ChatCommandManager.SendDebugMsgFormatted(DebugMsgType.SYNTAXERROR);
                ShowSyntax();
            }
            else if (split[1] == "minionsblue")
            {
                var champion = _playerManager.GetPeerInfo(peer).Champion;
                var random = new Random();

                var caster = new Minion(MinionSpawnType.MINION_TYPE_CASTER, MinionSpawnPosition.SPAWN_BLUE_BOT);
                var cannon = new Minion(MinionSpawnType.MINION_TYPE_CANNON, MinionSpawnPosition.SPAWN_BLUE_BOT);
                var melee = new Minion(MinionSpawnType.MINION_TYPE_MELEE, MinionSpawnPosition.SPAWN_BLUE_BOT);
                var super = new Minion(MinionSpawnType.MINION_TYPE_SUPER, MinionSpawnPosition.SPAWN_BLUE_BOT);

                const int X = 400;
                caster.SetPosition(champion.X + random.Next(-X, X), champion.Y + random.Next(-X, X));
                cannon.SetPosition(champion.X + random.Next(-X, X), champion.Y + random.Next(-X, X));
                melee.SetPosition(champion.X + random.Next(-X, X), champion.Y + random.Next(-X, X));
                super.SetPosition(champion.X + random.Next(-X, X), champion.Y + random.Next(-X, X));

                caster.PauseAi(true);
                cannon.PauseAi(true);
                melee.PauseAi(true);
                super.PauseAi(true);

                caster.SetWaypoints(new List<Vector2> { new Vector2(caster.X, caster.Y), new Vector2(caster.X, caster.Y) });
                cannon.SetWaypoints(new List<Vector2> { new Vector2(cannon.X, cannon.Y), new Vector2(cannon.X, cannon.Y) });
                melee.SetWaypoints(new List<Vector2> { new Vector2(melee.X, melee.Y), new Vector2(melee.X, melee.Y) });
                super.SetWaypoints(new List<Vector2> { new Vector2(super.X, super.Y), new Vector2(super.X, super.Y) });

                caster.SetVisibleByTeam(TeamId.TEAM_BLUE, true);
                cannon.SetVisibleByTeam(TeamId.TEAM_BLUE, true);
                melee.SetVisibleByTeam(TeamId.TEAM_BLUE, true);
                super.SetVisibleByTeam(TeamId.TEAM_BLUE, true);

                _game.ObjectManager.AddObject(caster);
                _game.ObjectManager.AddObject(cannon);
                _game.ObjectManager.AddObject(melee);
                _game.ObjectManager.AddObject(super);
            }
            else if (split[1] == "minionspurple")
            {
                var champion = _playerManager.GetPeerInfo(peer).Champion;
                var random = new Random();

                var caster = new Minion(MinionSpawnType.MINION_TYPE_CASTER, MinionSpawnPosition.SPAWN_RED_BOT);
                var cannon = new Minion(MinionSpawnType.MINION_TYPE_CANNON, MinionSpawnPosition.SPAWN_RED_BOT);
                var melee = new Minion(MinionSpawnType.MINION_TYPE_MELEE, MinionSpawnPosition.SPAWN_RED_BOT);
                var super = new Minion(MinionSpawnType.MINION_TYPE_SUPER, MinionSpawnPosition.SPAWN_RED_BOT);

                const int X = 400;
                caster.SetPosition(champion.X + random.Next(-X, X), champion.Y + random.Next(-X, X));
                cannon.SetPosition(champion.X + random.Next(-X, X), champion.Y + random.Next(-X, X));
                melee.SetPosition(champion.X + random.Next(-X, X), champion.Y + random.Next(-X, X));
                super.SetPosition(champion.X + random.Next(-X, X), champion.Y + random.Next(-X, X));

                caster.PauseAi(true);
                cannon.PauseAi(true);
                melee.PauseAi(true);
                super.PauseAi(true);

                caster.SetWaypoints(new List<Vector2> { new Vector2(caster.X, caster.Y), new Vector2(caster.X, caster.Y) });
                cannon.SetWaypoints(new List<Vector2> { new Vector2(cannon.X, cannon.Y), new Vector2(cannon.X, cannon.Y) });
                melee.SetWaypoints(new List<Vector2> { new Vector2(melee.X, melee.Y), new Vector2(melee.X, melee.Y) });
                super.SetWaypoints(new List<Vector2> { new Vector2(super.X, super.Y), new Vector2(super.X, super.Y) });

                caster.SetVisibleByTeam(TeamId.TEAM_PURPLE, true);
                cannon.SetVisibleByTeam(TeamId.TEAM_PURPLE, true);
                melee.SetVisibleByTeam(TeamId.TEAM_PURPLE, true);
                super.SetVisibleByTeam(TeamId.TEAM_PURPLE, true);

                _game.ObjectManager.AddObject(caster);
                _game.ObjectManager.AddObject(cannon);
                _game.ObjectManager.AddObject(melee);
                _game.ObjectManager.AddObject(super);
            }
        }
    }
}
