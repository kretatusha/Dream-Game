﻿using System;

namespace Source.Slime_Components
{
    public class Timer
    {
        private readonly Action _action;
        private float _currentTick;

        public Timer(float duration, Action action)
        {
            _action = action;
            _currentTick = duration;
        }
        
        public void Tick(float deltaTime)
        {
            if(_currentTick <= 0)
                return;
            _currentTick -= deltaTime;
            if (_currentTick <= 0)
                _action?.Invoke();
        }
    }}