using System;

namespace Bowling
{
    public class Game
    {
        private const int MAX_FRAMES = 10;

        private readonly Frame[] _frames;

        private int _currentIndex;
        private Frame _current;
        private Frame _previous;
        private Frame _beforePrevious;

        private bool _isFinal;
        private bool _isComplete;

        public Game()
        {
            _frames = new Frame[MAX_FRAMES];

            for (int i = 0; i < MAX_FRAMES; i++)
                _frames[i] = new Frame();

            _current = _frames[0];
            _previous = null;
            _beforePrevious = null;
        }

        public void Roll(int pins)
        {
            if (_isComplete)
            {
                throw new Exception("Game is complete, no more roll is allowed");
            }

            _current.Roll(pins);
            _previous?.CheckApplyBonus(pins);
            _beforePrevious?.CheckApplyBonus(pins);

            if (!_current.IsComplete)
            {
                return;
            }

            if (_isFinal && _current.CheckGrantExtraRoll())
            {
                return;
            }

            _beforePrevious = _previous;
            _previous = _current;
            _isComplete = _isFinal;

            if (_isComplete)
            {
                return;
            }

            _current = _frames[++_currentIndex];
            _isFinal = _currentIndex == MAX_FRAMES - 1;
        }

        public int Score()
        {
            if (!_isComplete)
            {
                throw new Exception("Game is not complete yet, so go on rolling...");
            }

            int score = 0;
            for (int i = 0; i < MAX_FRAMES; i++)
                score += _frames[i].Score;

            return score;
        }

        public string ScoreHistory()
        {
            string history = string.Empty;
            int score = 0;

            foreach (var frame in _frames)
            {
                score += frame.Score;
                history += $"{score};";
            }

            return history;
        }
    }
}
