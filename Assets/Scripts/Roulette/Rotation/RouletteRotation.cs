
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
//using System.Diagnostics.Eventing.Reader;

namespace AndroappsRoulette
{
    // [CreateAssetMenu(fileName = "Roulette", menuName = "Andro/Roulette")]
    public class RouletteRotation : MonoBehaviour
    {
        public static RouletteRotation Instance;
        public GameObject Obj;
        public GameObject ballRotator;
        public GameObject BallPoint;
        public GameObject Child;
        public int Winning;
        public float Rotate_Z_Update;
        public bool IsCheck;
        public bool IsStop;
       // public bool IsBet;
        public float speed;
        public float Speed_Ball;
        public List<Transform> Pos;
        public int FixedAngle;
        public float Interval;
        public EnterManager _EnterManager;

        private void Start()
        {
            Instance = this;
            Speed_Ball = speed = 300;
         //   SetRotation();          
        }

        public void OnButtonTesting()
        {
             IsCheck = true;
            _EnterManager.AgainStart();
        }
        private void FixedUpdate()
        {           
            if (IsCheck)
            {                
                ballRotator.transform.Rotate(Vector3.back * Speed_Ball * 3 * Time.deltaTime);
                Obj.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
                IsStop = true;               
            }

            else
            {
                if (speed > 0)
                    speed -= 1;
                else if (speed < 0)
                {
                    speed = 0;
                    Obj.transform.Rotate(0, 0, 0);
                }
            //    if (speed == 0)
            //    {
            //        // Quaternion qua = Obj.transform.localRotation;
            //        Obj.transform.eulerAngles = new Vector3(0, 0, Obj.transform.localEulerAngles.z);
            //        if (Obj.transform.localRotation.z == 0)
            //        {
            //            Debug.Log("(Rotate_Z_Update == 180 : " + Obj.transform.localRotation);
            //            Debug.Log("(Rotate == 180 : " + Obj.transform.eulerAngles);

            //        }
            //        else if (Obj.transform.localRotation.z > 0)
            //        {
            //            // Debug.Log("(Rotate_Z_Update >180 : " + Obj.transform.localRotation);

            //            if (IsStop)
            //            {
            //                Debug.Log("(Rotat >180 : " + Obj.transform.eulerAngles);
            //                IsStop = false;
            //                // Obj.transform.DORotate(new Vector3(0, 0, (Obj.transform.eulerAngles.z - Obj.transform.eulerAngles.z)), 0).OnComplete(SetValue);
            //                //Obj.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //                //Obj.transform.DOShakeRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //                //  SetRotation();
            //            }
            //        }
            //        else if (Obj.transform.localRotation.z < 0)
            //        {
            //            //  Debug.Log("(Rotate_Z_Update local < 180 : " + Obj.transform.localRotation);
            //            Debug.Log("(Rotat < 180 : " + Obj.transform.eulerAngles);
            //        }
            //        // SetValue();
            //        //Debug.Log("Rot :  ");
            //    }
            //    else
            //    {
            //        // Debug.Log("Rot else  :  " + Obj.transform.rotation);
            //        Rotate_Z_Update = speed * Time.deltaTime;
            //        Obj.transform.Rotate(0, 0, Rotate_Z_Update);
            //    }
            }
        }

        public void SetRotation()
        {
          //  Debug.Log("Set Rotation");
            for (int i = 0; i < Pos.Count; i++)
            {
                Pos[i].GetComponent<Collider>().enabled = false;
            }

            switch (Winning)
            {

                case 0: Pos[0].GetComponent<Collider>().enabled = true; break;
                case 1: Pos[1].GetComponent<Collider>().enabled = true; break;
                case 2: Pos[2].GetComponent<Collider>().enabled = true; break;
                case 3: Pos[3].GetComponent<Collider>().enabled = true; break;
                case 4: Pos[4].GetComponent<Collider>().enabled = true; break;
                case 5: Pos[5].GetComponent<Collider>().enabled = true; break;
                case 6: Pos[6].GetComponent<Collider>().enabled = true; break;
                case 7: Pos[7].GetComponent<Collider>().enabled = true; break;
                case 8: Pos[8].GetComponent<Collider>().enabled = true; break;
                case 9: Pos[9].GetComponent<Collider>().enabled = true; break;
                case 10: Pos[10].GetComponent<Collider>().enabled = true; break;
                case 11: Pos[11].GetComponent<Collider>().enabled = true; break;
                case 12: Pos[12].GetComponent<Collider>().enabled = true; break;
                case 13: Pos[13].GetComponent<Collider>().enabled = true; break;
                case 14: Pos[14].GetComponent<Collider>().enabled = true; break;
                case 15: Pos[15].GetComponent<Collider>().enabled = true; break;
                case 16: Pos[16].GetComponent<Collider>().enabled = true; break;
                case 17: Pos[17].GetComponent<Collider>().enabled = true; break;
                case 18: Pos[18].GetComponent<Collider>().enabled = true; break;
                case 19: Pos[19].GetComponent<Collider>().enabled = true; break;
                case 20: Pos[20].GetComponent<Collider>().enabled = true; break;
                case 21: Pos[21].GetComponent<Collider>().enabled = true; break;
                case 22: Pos[22].GetComponent<Collider>().enabled = true; break;
                case 23: Pos[23].GetComponent<Collider>().enabled = true; break;
                case 24: Pos[24].GetComponent<Collider>().enabled = true; break;
                case 25: Pos[25].GetComponent<Collider>().enabled = true; break;
                case 26: Pos[26].GetComponent<Collider>().enabled = true; break;
                case 27: Pos[27].GetComponent<Collider>().enabled = true; break;
                case 28: Pos[28].GetComponent<Collider>().enabled = true; break;
                case 29: Pos[29].GetComponent<Collider>().enabled = true; break;
                case 30: Pos[30].GetComponent<Collider>().enabled = true; break;
                case 31: Pos[31].GetComponent<Collider>().enabled = true; break;
                case 32: Pos[32].GetComponent<Collider>().enabled = true; break;
                case 33: Pos[33].GetComponent<Collider>().enabled = true; break;
                case 34: Pos[34].GetComponent<Collider>().enabled = true; break;
                case 35: Pos[35].GetComponent<Collider>().enabled = true; break;
                case 36: Pos[36].GetComponent<Collider>().enabled = true; break;

            }
        }

        void SetValue()
        {
            switch (Winning)
            {

                case 0: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 347.1f)), Interval); break;//-13.2
                                                                                                          //case 0: Obj.transform.DORotate(new Vector3(0, 0, -13.1f), 1); break;//-13.2
                case 1: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 211)), Interval); break;
                case 2: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 45f)), Interval); break;
                case 3: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 326)), Interval); break;//-34
                case 4: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 25.19f)), Interval); break;
                case 5: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 171.2f)), Interval); break;
                case 6: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 85f)), Interval); break;
                case 7: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 288)), Interval); break;
                case 8: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 141.7f)), Interval); break;
                case 9: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 248)), Interval); break;
                case 10: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 162f)), Interval); break;
                case 11: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 122.6f)), Interval); break;
                case 12: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 307.5f)), Interval); break;
                case 13: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 102)), Interval); break;
                case 14: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 229)), Interval); break;
                case 15: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 6.3f)), Interval); break;
                case 16: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 191)), Interval); break;
                case 17: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 63f)), Interval); break;
                case 18: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 269f)), Interval); break;
                case 19: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 15.12f)), Interval); break;
                case 20: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 220)), Interval); break;
                case 21: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 34.3f)), Interval); break;
                case 22: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 258)), Interval); break;
                case 23: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 151.3f)), Interval); break;
                case 24: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 182f)), Interval); break;
                case 25: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 55f)), Interval); break;
                case 26: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 336.5f)), Interval); break;
                case 27: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 94)), Interval); break;
                case 28: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 299)), Interval); break;
                case 29: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 279f)), Interval); break;
                case 30: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 132.9f)), Interval); break;
                case 31: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 239)), Interval); break;
                case 32: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + -3.1f)), Interval); break;//-3.1
                case 33: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 200f)), Interval); break;//-160
                case 34: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 73f)), Interval); break;
                case 35: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 318f)), Interval); break;//-42
                case 36: Obj.transform.DORotate(new Vector3(0, 0, (FixedAngle + 112.8f)), Interval); break;
            }
            // ballRotator.transform.rotation = Obj.transform.rotation;
            ballRotator.transform.rotation = Quaternion.Euler(0, 0, Obj.transform.rotation.z + 92.5f);

        }


        public void OnRoationRoulette()
        {
            Debug.Log("To Rotation ");
            Obj.transform.DORotate(new Vector3(0, 0, 90), 1).OnComplete(R1);
        }
        void R1()
        {
            Obj.transform.DORotate(new Vector3(0, 0, 180), 1).OnComplete(R2);
        }
        void R2()
        {
            Obj.transform.DORotate(new Vector3(0, 0, 245), 1).OnComplete(R3);
        }
        void R3()
        {
            var Rot_Z = Winning;
            Debug.Log("Rot Z : " + Rot_Z);
            Obj.transform.DORotate(new Vector3(0, 0, Rot_Z), 1);
            Debug.Log("Rot Z : " + Obj.transform.eulerAngles);
        }
    }
}
