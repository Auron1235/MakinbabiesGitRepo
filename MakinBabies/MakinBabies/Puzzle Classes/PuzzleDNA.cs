using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakinBabies
{
    class PuzzleDNA
    {
        #region Declarations
        ContentManager Content;

        private Button dnaChoiceAT;
        private Button dnaChoiceTA;
        private Button dnaChoiceCG;
        private Button dnaChoiceGC;
        private Button accept;

        private List<Button> currentChoices;

        private List<Button> answers;
        private Random rng;
        private bool isPassed;
        #endregion

        #region Gets/Sets
        public Button DnaChoiceAT
        {
            get { return dnaChoiceAT; }
            set { dnaChoiceAT = value; }
        }
        public Button DnaChoiceCG
        {
            get { return dnaChoiceCG; }
            set { dnaChoiceCG = value; }
        }
        public Button Accept
        {
            get { return accept; }
            set { accept = value; }
        }
        public bool IsPassed
        {
            get { return isPassed; }
            set { isPassed = value; }
        }
        #endregion

        #region Methods
        public PuzzleDNA(ContentManager Content)
        {
            this.Content = Content;
            dnaChoiceAT = new Button(Content, "Jar", new Vector2(100, 100));
            dnaChoiceCG = new Button(Content, "Jar", new Vector2(100, 150));
            accept = new Button(Content, "Jar", new Vector2(100, 200));

            currentChoices = new List<Button>();
            answers = new List<Button>();
            CreatePuzzle();
        }
        public void CreatePuzzle()
        {
            currentChoices.Clear();
            Generate();
        }
        public void Generate()
        {
            for (int i = 0; i < 3; i++)
            {
                rng = new Random();
                if (rng.Next(1, 5) == 1) answers.Add(new Button(Content, "Jar", new Vector2(600, 100 + i * 50)));
                if (rng.Next(1, 5) == 2) answers.Add(new Button(Content, "Jar", new Vector2(600, 100 + i * 50)));
                if (rng.Next(1, 5) == 3) answers.Add(new Button(Content, "Jar", new Vector2(600, 100 + i * 50)));
            }
        }
        public void IsCorrect()
        {
            if (currentChoices[0].BaseImage == answers[0].BaseImage && currentChoices[1].BaseImage == answers[1].BaseImage && currentChoices[2].BaseImage == answers[2].BaseImage)
                isPassed = true;
            else isPassed = false;
        }
        public void Update()
        {
            dnaChoiceAT.Update();
            dnaChoiceCG.Update();
            accept.Update();
            if (dnaChoiceAT.IsPressed && !dnaChoiceAT.IsFlipped && currentChoices.Count < 3) currentChoices.Add(new Button(Content, "Jar", new Vector2(0, 0)));
            if (dnaChoiceCG.IsPressed && !dnaChoiceCG.IsFlipped && currentChoices.Count < 3) currentChoices.Add(new Button(Content, "Jar", new Vector2(0, 0)));

            if (dnaChoiceAT.IsPressed && dnaChoiceAT.IsFlipped) /*Rightclick CG logic*/;
            if (dnaChoiceCG.IsPressed && dnaChoiceCG.IsFlipped) /*Rightclick GC logic*/;

            for (int i = 0; i < currentChoices.Count; i++)
            {
                currentChoices[i].Update();
                currentChoices[i].Position = new Vector2(400, 100 + i * 50);
                if (currentChoices[i].IsPressed)
                {
                    currentChoices.RemoveAt(i);
                    break;
                }
            }
            if (accept.IsPressed) CreatePuzzle();
        }
        public void Draw(SpriteBatch sb)
        {
            dnaChoiceAT.Draw(sb);
            dnaChoiceCG.Draw(sb);
            accept.Draw(sb);
            foreach (var button in answers)
            {
                button.Draw(sb);
            }

            foreach (var button in currentChoices)
            {
                button.Draw(sb);
            }
        }
        #endregion
    }
}
