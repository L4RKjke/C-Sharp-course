using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardGame test = new CardGame();
            test.Game();
        }
    }

    class CardGame
    {
        private Deck _deck;
        private Player _player;
        private Card _card;

        public void Game()
        {
            bool isPlaying = true;
            _deck.GenerateDeck();
            while (isPlaying == true)
            {
                Console.Clear();
                Console.WriteLine($"Взять карту - 1, 2 - Показать карты, которые были вытянуты");
                char command = Convert.ToChar(Console.ReadKey(true).Key);

                switch (command)
                {
                    case '1':
                        _player.AddCard();
                        _deck.RemoveCard();

                        break;

                    case '2':

                        _player.ShowPlayerCards();
                        Console.WriteLine("Чтобы продолжить нажмите любую кнопку...");
                        Console.ReadKey(true);
                        isPlaying = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }

    class Deck
    {
        private int _specificСardType = 0;
        private int _maxCardsInDeck = 36;
        private string _randomCard;
        private int _maxNumberOfSameType = 4;
        private Stack<Card> _cards = new Stack<Card>();
        private List<string> _cardsNames = new List<string>();
        private Dictionary<string, int> _deck = new Dictionary<string, int>()
        {
            {"Шестерка", 6},
            {"Семерка", 7},
            {"Весьмерка", 8},
            {"Девятка", 9},
            {"Десятка", 10},
            {"Валет", 2},
            {"Дама", 3},
            {"Король", 4},
            {"Туз", 11}
        };

        public void AddCard(string name, int value)
        { 
            _cards.Push(new Card(name, value));
        }

        public Card RemoveCard()
        {
            return _cards.Pop();
        }

        public void ShowAllCards()
        {
            foreach (Card card in _cards)
            {
                Console.WriteLine(card.ShowCard());
            }
        }

        public void GenerateDeck()
        {
            Random random = new Random();
            while (_cards.Count() < _maxCardsInDeck)
            {
                int c = 0;

                foreach (var card in _deck)
                {

                    if (c == random.Next(0, 9))
                    {
                        _randomCard = card.Key;
                        _specificСardType = 0;

                        foreach (var elem in _cardsNames)
                        {
                            if (_randomCard == elem)
                            {
                                _specificСardType++;
                            }
                        }

                        if (_specificСardType < _maxNumberOfSameType)
                        {
                            _cards.Push(new Card(_randomCard, _deck[_randomCard]));
                            _cardsNames.Add(_randomCard);
                        }
                    }
                    c++;
                }
            }
        }
    }

    class Card
    {
        public string _name { get; private set; }
        
        public int _cardValue { get; private set; }

        public Card(string name, int cardValue)
        {
            _name = name;
            _cardValue = cardValue;
        }

        public string ShowCard()
        {
            return ($"{_name}, {_cardValue}");
        }
    }

    class Player
    {
        private Card _card;
        private List<Card> _playerCards = new List<Card>();

        public void AddCard(Card card)
        {
            _playerCards.Add(card);
        }

        public void RemoveCards()
        {
            _playerCards.Clear();
        }

        public void ShowPlayerCards()
        {
            foreach (var card in _playerCards)
            {
                Console.WriteLine(card.ShowCard());
            }
        }
    }
}