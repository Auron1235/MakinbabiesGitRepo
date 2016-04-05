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
        private Button confirm;

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
            get { return confirm; }
            set { confirm = value; }
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
            rng = new Random();
            dnaChoiceAT = new Button(Content, "DNA-AT", new Vector2(500, 200));
            dnaChoiceTA = new Button(Content, "DNA-TA", new Vector2(500, 260));
            dnaChoiceCG = new Button(Content, "DNA-CG", new Vector2(500, 320));
            dnaChoiceGC = new Button(Content, "DNA-GC", new Vector2(500, 380));
            confirm = new Button(Content, "ConfirmButton", new Vector2(500, 450));

            currentChoices = new List<Button>();
            answers = new List<Button>();

            Create();
        }
        public void Create()
        {
            currentChoices.Clear();
            answers.Clear();
            Generate();
        }
        public void Generate()
        {
            for (int i = 0; i < 5; i++)
            {
                int randInt = rng.Next(1, 5);
                if (randInt == 1) answers.Add(new Button(Content, "DNA-AT", new Vector2(1000, 200 + i * 60)));
                if (randInt == 2) answers.Add(new Button(Content, "DNA-TA", new Vector2(1000, 200 + i * 60)));
                if (randInt == 3) answers.Add(new Button(Content, "DNA-GC", new Vector2(1000, 200 + i * 60)));
                if (randInt == 4) answers.Add(new Button(Content, "DNA-CG", new Vector2(1000, 200 + i * 60)));
            }
        }
        public void Update()
        {
            if (dnaChoiceAT.IsPressed && currentChoices.Count < 5) currentChoices.Add(new Button(Content, "DNA-AT", new Vector2(-1000, -1000)));
            if (dnaChoiceCG.IsPressed && currentChoices.Count < 5) currentChoices.Add(new Button(Content, "DNA-CG", new Vector2(-1000, -1000)));
            if (dnaChoiceTA.IsPressed && currentChoices.Count < 5) currentChoices.Add(new Button(Content, "DNA-TA", new Vector2(-1000, -1000)));
            if (dnaChoiceGC.IsPressed && currentChoices.Count < 5) currentChoices.Add(new Button(Content, "DNA-GC", new Vector2(-1000, -1000)));

            dnaChoiceAT.Update();
            dnaChoiceTA.Update();
            dnaChoiceCG.Update();
            dnaChoiceGC.Update();

            confirm.Update();

            for (int i = 0; i < currentChoices.Count; i++)
            {
                currentChoices[i].Update();
                currentChoices[i].Position = new Vector2(750, 200 + i * 60);
                if (currentChoices[i].IsPressed)
                {
                    currentChoices.RemoveAt(i);
                    break;
                }
            }
            if (currentChoices.Count == 5)
            {
                if (currentChoices[0].BaseImage == answers[0].BaseImage && currentChoices[1].BaseImage == answers[1].BaseImage && currentChoices[2].BaseImage == answers[2].BaseImage && currentChoices[3].BaseImage == answers[3].BaseImage && currentChoices[4].BaseImage == answers[4].BaseImage)
                    isPassed = true;
            }
            else isPassed = false;
            if (confirm.IsPressed) Create();
        }
        public void Draw(SpriteBatch sb)
        {
            dnaChoiceAT.SpriteSheetDraw(sb);
            dnaChoiceTA.SpriteSheetDraw(sb);
            dnaChoiceCG.SpriteSheetDraw(sb);
            dnaChoiceGC.SpriteSheetDraw(sb);
            confirm.SpriteSheetDraw(sb);
            foreach (var button in answers)
            {
                button.SpriteSheetDraw(sb);
            }

            foreach (var button in currentChoices)
            {
                button.SpriteSheetDraw(sb);
            }
        }
        #endregion
    }
}
