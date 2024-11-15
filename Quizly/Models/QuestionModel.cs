﻿using Quizly.Entities;

namespace Quizly.Models;

public class QuestionModel
{
    public string? QuestionText { get; set; }
    public List<Answer> Answers { get; set; } = [];
    public int CorrectAnswerIndex { get; set; }
}