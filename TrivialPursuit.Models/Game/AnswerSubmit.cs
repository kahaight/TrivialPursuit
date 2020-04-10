using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Data.DataClasses;
using TrivialPursuit.Models.Question;

namespace TrivialPursuit.Models.Game
{
    public class AnswerSubmit // this object is instantiated when a new game is started
    {
        public Game Game { get; set; }
        public List<QuestionDetail> AnsweredQuestions { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; } // may not need this
        public QuestionDetail CurrentQuestion { get; set; } // may not need this
        public bool GameOver { get; set; }

        // public bool GameOver maybe the default value is false, when we call our controller method we will toggle it to true





        //Start a new game, this model will be instantiated
        //we will pass this model to our view 
        //Question will appear in view, user will input an answer
        //model returns to SubmitAnswer
        //Answer is evaluated, score or whatever is tallied
        //if end game condition is met, we will toggle GameOver to True
        //if GameOver is True return View for end of game, Post to DataBase
        //if GameOver is false redirectToAction(Game) will need to give it a route value for model.game.id
        
        // Were gonna need a new Action Method for ongoing game
        //OngoingGame Action Method will need a conditional for ifAnswerSubmit.GameOver == false
        
        //
        //we will need to use route values to pass our AnswerSubmit model around to the different methods and views with out instantiating a new game


















    }
}
