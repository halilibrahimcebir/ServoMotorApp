﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoControlApp
{

    public class cls_PID_Control_Axis1
    {
        private float Kp;   // Proportional constant
        private float Ki;   // Integral constant
        private float Kd;   // Derivative constant
        public byte[] SendOut = new byte[8];
        public float setPoint;    // Target set point
        private float integralTerm;    // Integral term
        private float integral, previousError;
        private float lastError;   // Last error for derivative term
        public float range_torque = 100;
        public float range_vel = 40;
        public float out_pid;
        float error;
        float derivative;
        float output;


        public static bool pid_canwork;
        exoskeleton cls = new exoskeleton();
        public cls_PID_Control_Axis1(float kp, float ki, float kd, float initialSetPoint)
        {
            Kp = kp;
            Ki = ki;
            Kd = kd;
            setPoint = initialSetPoint;

            integralTerm = 0;
            lastError = 0;
        }

        public double Calculate(float currentValue)
        {
            // Calculate error


            // Proportional term
            if (currentValue == setPoint)
            {
                Reset();
            }
            error = setPoint - currentValue;
    

            integral += error;
     
            derivative = (error - previousError);
        
            output = Kp * error + Ki * integral + Kd * derivative;
            if (output < 0)
            {
                output = 0;
            }
            if (output > 120)
            {
                output = 120;

            }

           
            previousError = error;
            
            if (integral > 10)
            {
                integral = 10;
            }
            else if (integral < -10)
            {
                integral = -10;
            }
            // Output sınırlarını kontrol et
            output = output / 6f;
           

            // Console.WriteLine("pid output" + out_pid.ToString()+ "!!!!!"+error+ "!!!!!" + proportionalTerm.ToString()+ "!!!!!" + integralComponent.ToString()+ "!!!!!" + derivativeComponent.ToString());
            // out_pid = -20 + out_pid;
            if (pid_canwork)
            {

                Console.WriteLine("pid canAX1" + output);
                cls.ConvertFloatFirst_Ax1(output );
                //    Console.WriteLine(out_pid + "pid cıkıs hızı" + currentValue.ToString()) ;
            }

            return output;
        }
        public void SetSetPoint(float newSetPoint)
        {
            setPoint = newSetPoint;
        }

        public void Reset()
        {
            if (pid_canwork)
            {
                cls.ConvertFloatFirst_Ax1(0f);
                integral = 0;
                previousError = 0;
                error = 0;
                derivative = 0;
             
            }
        }



    }
}


