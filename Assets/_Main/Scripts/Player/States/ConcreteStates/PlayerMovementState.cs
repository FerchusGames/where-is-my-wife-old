using System;
using UniRx;
using UnityEngine;
using WhereIsMyWife.Controllers;
using WhereIsMyWife.Player.StateMachine;
using Zenject;

namespace WhereIsMyWife.Player.State
{
    public class PlayerMovementState : PlayerState, IMovementStateEvents
    {
        public PlayerMovementState() : base(PlayerStateMachine.PlayerState.Movement) { }
        
        private ISubject<float> _jumpStartSubject = new Subject<float>();
        private ISubject<float> _runSubject = new Subject<float>();
        private ISubject<Unit> _turnSubject = new Subject<Unit>();
        private ISubject<float> _gravityScaleSubject = new Subject<float>();
        private ISubject<float> _fallSpeedCapSubject = new Subject<float>();

        public IObservable<float> JumpStart => _jumpStartSubject.AsObservable();
        public IObservable<float> Run => _runSubject.AsObservable();
        public IObservable<Unit> Turn => _turnSubject.AsObservable();
        public IObservable<float> GravityScale => _gravityScaleSubject.AsObservable();
        public IObservable<float> FallSpeedCap => _fallSpeedCapSubject.AsObservable();
        
        private IDisposable _jumpStartSubscription;
        private IDisposable _runSubscription;
        private IDisposable _turnSubscription;
        private IDisposable _gravityScaleSubscription;
        private IDisposable _fallSpeedCapSubscription;
        
        private float _runAcceleration;
        
        protected override void SubscribeToObservables()
        {
            _jumpStartSubscription = _playerStateInput.JumpStart.Subscribe(_jumpStartSubject.OnNext);
            _runSubscription = _playerStateInput.Run.Subscribe(_runSubject.OnNext);
            _turnSubscription = _playerStateInput.Turn.Subscribe(_turnSubject.OnNext);
            _gravityScaleSubscription = _playerStateInput.GravityScale.Subscribe(_gravityScaleSubject.OnNext);
            _fallSpeedCapSubscription = _playerStateInput.FallSpeedCap.Subscribe(_fallSpeedCapSubject.OnNext);
        }

        protected override void UnsubscribeToObservables()
        {
            // Dispose of the subscriptions to unsubscribe
            _jumpStartSubscription?.Dispose();
            _runSubscription?.Dispose();
            _turnSubscription?.Dispose();
            _gravityScaleSubscription?.Dispose();
            _fallSpeedCapSubscription?.Dispose();
        }
    }
}