﻿using Akka.Actor;
using AkkaOfEmpires.ConsoleUI.ConsoleActors;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Units;

namespace AkkaOfEmpires.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = AkkaOfEmpiresSystem.Start();

            var supervisorProps = Props.Create<ConsoleResourcesSupervisorActor>();
            var supervisor = system.ActorOf(supervisorProps);

            var villagerProps = Props.Create<VillagerActor>(supervisor);
            var villager = system.ActorOf(villagerProps);

            villager.Tell(new GatherFruits());

            system.AwaitTermination();
        }
    }
}