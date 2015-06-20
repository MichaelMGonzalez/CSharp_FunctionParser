﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathFunctionParser
{
    /** This class represents a node in the evaluation tree
     *  Generated by the Parser
     */
    class EvaluatorNode
    {
        // Fields
        private EvaluatorNode leftNode;
        private EvaluatorNode rightNode;
        public Func<double, double, double> evalFunc;

        // Constructors
        public EvaluatorNode() { }
        public EvaluatorNode(EvaluatorNode left, EvaluatorNode right)
        {
            leftNode = left;
            rightNode = right;
        }

        // Methods
        public virtual double Evaluate()
        {
            return evalFunc(leftNode.Evaluate(), rightNode.Evaluate());
        }
    }
    class ConstantNode : EvaluatorNode
    {
        // Fields
        private double value;

        // Constructor
        public ConstantNode(double value) { 
            this.value = value;
            this.evalFunc = delegate(double l, double r)
            {
                return value;
            };
        }

        // Methods
        override public double Evaluate() { return evalFunc(0,0); }
    }
    class VariableNode : EvaluatorNode
    {
        // Fields
        private string varName;
        private SortedDictionary<string, double> varDB;

        // Constructor
        public VariableNode(string name, SortedDictionary<string, double> db)
        {
            this.varName = name;
            varDB = db;
            evalFunc = delegate(double l, double r)
            {
                return varDB[varName];
            };
        }

        // Methods
        public override double Evaluate()
        {
            return evalFunc(0, 0);
        }

    }
}
