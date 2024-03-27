﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__GC.Entity;

namespace C__GC.Combats
{
    static class Status
    {
        static Action _triggerStatus;

        public static void Subscribe(Action trigger)
        {
            _triggerStatus += trigger;
        }

        public static void Tick()
        {
            _triggerStatus?.Invoke();
        }

        public static void Burn(Character target)
        {
            target.TakeDmg(15);
        }

    }
}
