using AndroApps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AndroAppsRoulette
{
    public class RouletteCoinItems : MonoBehaviour
    {
        public int CoinId;
        public Button btn;
        public GameObject ChildCoin;
        public GameObject PrefabCoin;

        private Transform Parent;
        public Transform firstpos;



        private void Awake()
        {
            // Defualt value calling ...
            GameModule.Instance.GetActiveGameDetail.Coin = 10;
            CoinInside(10);

            btn = this.GetComponent<Button>();
            btn.onClick.AddListener(OnCoinValue);
            ChildCoin = this.transform.GetChild(0).gameObject;

        }

        public void OnCoinValue()
        {
            Debug.Log("Click Coin " + CoinId);
            GameModule.Instance.GetActiveGameDetail.Coin = CoinId;
            CoinInside(CoinId); 
        }

        public void CoinInside(int Index)
        {
            switch (Index)
            {
                case 10:
                    {
                        GameModule.Instance.GetActiveGameDetail.CoinSprite = GameModule.Instance.GetActiveGameDetail.CoinSprit[0];
                        GameModule.Instance.GetActiveGameDetail.CoinIndex = 0;
                        // GameModule.Instance.GetActiveGameDetail.firstpos = RouletteManager.Instance.ChildCoin[0].transform;
                        firstpos = RouletteManager.Instance.ChildCoin[0].transform;
                        RouletteManager.Instance.FirstPos = firstpos;
                        break;
                    }
                case 50:
                    {
                        GameModule.Instance.GetActiveGameDetail.CoinSprite = GameModule.Instance.GetActiveGameDetail.CoinSprit[1];
                        GameModule.Instance.GetActiveGameDetail.CoinIndex = 1;
                        // GameModule.Instance.GetActiveGameDetail.firstpos = RouletteManager.Instance.ChildCoin[1].transform;
                        firstpos = RouletteManager.Instance.ChildCoin[1].transform; 
                        RouletteManager.Instance.FirstPos = firstpos;
                        break;
                    }
                case 100:
                    {
                        GameModule.Instance.GetActiveGameDetail.CoinSprite = GameModule.Instance.GetActiveGameDetail.CoinSprit[2];
                        GameModule.Instance.GetActiveGameDetail.CoinIndex = 2;
                        // GameModule.Instance.GetActiveGameDetail.firstpos = RouletteManager.Instance.ChildCoin[2].transform;
                        firstpos = RouletteManager.Instance.ChildCoin[2].transform;
                        RouletteManager.Instance.FirstPos = firstpos;
                        break;
                    }
                case 1000:
                    {
                        GameModule.Instance.GetActiveGameDetail.CoinSprite = GameModule.Instance.GetActiveGameDetail.CoinSprit[3];
                        GameModule.Instance.GetActiveGameDetail.CoinIndex = 3;
                        // GameModule.Instance.GetActiveGameDetail.firstpos = RouletteManager.Instance.ChildCoin[3].transform;
                        firstpos = RouletteManager.Instance.ChildCoin[3].transform;
                        RouletteManager.Instance.FirstPos = firstpos;
                        break;
                    }
                case 5000:
                    {
                        GameModule.Instance.GetActiveGameDetail.CoinSprite = GameModule.Instance.GetActiveGameDetail.CoinSprit[4];
                        GameModule.Instance.GetActiveGameDetail.CoinIndex = 4;
                        // GameModule.Instance.GetActiveGameDetail.firstpos = RouletteManager.Instance.ChildCoin[4].transform;
                        firstpos = RouletteManager.Instance.ChildCoin[4].transform;
                        RouletteManager.Instance.FirstPos = firstpos;
                        break;
                    }

            }

           
            Coin(GameModule.Instance.GetActiveGameDetail.CoinIndex); // effect 

        }
        void Coin(int index)
        {
            for (int i = 0; i < RouletteManager.Instance.ChildCoin.Count; i++)
            {
                RouletteManager.Instance.ChildCoin[i].SetActive(false);
            }
            RouletteManager.Instance.ChildCoin[index].SetActive(true);
        }
    }
}