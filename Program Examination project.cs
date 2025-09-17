using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace projectOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class course
    {
        string title;
        string description;
        int max_degree;

        public int MAX_dgree { get; set; }
        public  course (string title, string description , int max_degree)
        {
            this.title = title;
            this.description = description;
            MAX_dgree = max_degree;

        }
    }
    class student
    {
        int ID;
        string Name;
        string Email;
        List<course> enrollCourses = new List<course>();
        public student(int ID  , string Name ,string Email)
        {
            this .ID = ID;  
            this.Name = Name;
            this.Email = Email;
        }
        public void EnrollCourse(course c)
        {
            enrollCourses.Add(c);
        }
        public void take_exam(exam e)
        {

            int total_score=0;
           foreach(var q in e.Questions)
            {
                Console.WriteLine(q.Text);
                string answer=Console.ReadLine();
                if (q.ckeck_answer(answer))
                {
                    total_score += q.Mark;
                }
            }
            Console.WriteLine($"final score : {total_score} / {e.followCourse.MAX_dgree}");
            


        }




    }
    class instructor
    {
        int ID;
        string Name;
        string Specialization;
        List<course> techingCourses=new List<course>();
        public instructor(int ID , string Name ,string Specialization)
        {
            this.ID=ID;
            this.Name = Name;
            this.Specialization = Specialization;
        }
        public void TechingCourses(course c)
        {
            techingCourses.Add(c);
        }
    }

    class question
    {
        string text;
        int mark;
        public int Mark { get; set; }
        public string Text { get; set; }
        public question(string text, int mark)
        {
            Text = text;
            Mark= mark;
        }
        public virtual bool ckeck_answer(string answer)
        {

            return false;
        }
    }
    class Multible_choice : question
    {
        List<string> choices =new List<string>();
        string correct_answer;

        public Multible_choice(string text, int mark  ,List<string> choices ,string correct_answer) : base(text, mark)
        {
            this.choices = choices;
            this.correct_answer = correct_answer;
        }
        public override bool ckeck_answer(string answer)
        {
            return correct_answer==answer;
        }
    }

    class TrueFalse : question
    {
        bool correct_answer;

        public TrueFalse(string text, int mark ,bool correct_answer) : base(text, mark)
        {
            this.correct_answer = correct_answer;
        }
        public  bool ckeckk_answer(bool answer)
        {
            return correct_answer == answer;
        }
    }

    class essay : question
    {
        public essay(string text, int mark) : base(text, mark)
        {
        }
    }

    class exam
    {
       public List<question> Questions=new List<question>();
        public course  followCourse { get; set; }
        public bool islocked { get; set; }
        public exam(course c ,List<question> Questions)
        {
            followCourse = c;
            islocked = false;
            this.Questions = Questions;
        }

        public exam()
        {
        }

        public void lock_exam()
        {
            islocked = true;
        }

        public void add(question q)
        {

            int currentTotal = 0;
            foreach (question Q in Questions)
            {
                currentTotal += q.Mark;

            }
            if (islocked)
            {
                Console.WriteLine("can't add anything ,exam is locked");
                return;
            }
            course c = followCourse;
            if (currentTotal + q.Mark > c.MAX_dgree)
            {
                Console.WriteLine("can't add anything , max degrees");
                return;
            }
            Questions.Add(q);
            Console.WriteLine("adding success");
        }
        public void editing(question q ,string text ,int mark )
        {
            if (islocked)
            {
                Console.WriteLine("can't edit anything ,exam is locked");
                return;
            }
            foreach (question Q in Questions)
            {
                if (Q.Text == q.Text)
                {
                    Q.Text = text;
                    Q.Mark = mark;
                    return;
                }
            }
        }
        public void RemoveQuestion (question q)
        {
            foreach (question Q in Questions)
            {
                if (Q.Text == q.Text)
                {
                   Questions.Remove(Q);
                    return;
                }
            }
        }
        public void assignMarks(question q ,int mark)
        {
            foreach (question Q in Questions)
            {
                if (Q.Text == q.Text)
                {
                   Q.Mark= mark;
                    return;
                }
            }
        }

        public exam duplicate(course newcourse)
        {
            exam copy_exam = new exam(newcourse,Questions);
            return copy_exam;
        }




    }





}















