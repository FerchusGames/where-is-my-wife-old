﻿using System;
using UniRx;
using UnityEngine;

namespace WhereIsMyWife.Controllers
{
    public interface IMovementStateEvents
    {
        IObservable<float> JumpStart { get; }
        IObservable<float> Run { get; }
        IObservable<Unit> Turn { get; }
        IObservable<float> GravityScale { get; }
        IObservable<float> FallSpeedCap { get; }
    }

    public interface IDashStateEvents
    {
        IObservable<Vector2> Dash { get; }
    }

    public interface IHookStateEvents
    {
        
    }
}