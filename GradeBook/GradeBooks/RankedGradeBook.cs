﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked Grading requires a minimum of 5 students to work.");
            }

            var threshold = (int)Math.Ceiling(this.Students.Count * 0.2);

            var grades = this.Students
                .OrderByDescending(e => e.AverageGrade)
                .Select(e => e.AverageGrade).ToList();

            if (grades[threshold-1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[(threshold * 2) -1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[(threshold * 3) -1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[(threshold * 4) -1] <= averageGrade)
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");

                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");

                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
