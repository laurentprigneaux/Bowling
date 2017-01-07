using System;

namespace Bowling
{
    public class Frame
    {
        private const int MAX_PINS = 10;
        private const int MAX_ROLLS = 3;

        private bool _isLastTry;
        private int _totalPins;
        private int _rolls;
        private int _pendingBonus;

        public int Score { get; private set; }
        public bool IsComplete { get; private set; }
        public bool IsSpare { get; private set; }
        public bool IsStrike { get; private set; }

        public void Roll(int pins)
        {
            if (IsComplete)
            {
                throw new Exception("Frame is already complete, cannot roll anymore within this frame");
            }

            if (pins < 0 || pins + _totalPins > MAX_PINS)
            {
                throw new ArgumentException("Inconsistent number of pins for that roll");
            }

            Score += pins;
            _totalPins += pins;
            _rolls++;

            if (_totalPins == MAX_PINS)
            {
                if (_isLastTry)
                {
                    IsSpare = true;
                    _pendingBonus = 1;
                }
                else
                {
                    IsStrike = true;
                    _pendingBonus = 2;
                }

                IsComplete = true;
                return;
            }

            IsComplete = _isLastTry || _rolls == MAX_ROLLS;
            _isLastTry = true;
        }

        public void CheckApplyBonus(int pins)
        {
            if (_pendingBonus == 0)
            {
                return;
            }

            Score += pins;
            _pendingBonus--;
        }

        public bool CheckGrantExtraRoll()
        {
            if (_rolls < MAX_ROLLS && (IsStrike || IsSpare))
            {
                _isLastTry = false;
                _totalPins = 0;
                IsComplete = false;
                IsSpare = false;
                IsStrike = false;
                return true;
            }

            return false;
        }
    }
}
