using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
        //ボールが見える可能性のあるz軸の最大値
        private float visiblePosZ = -6.5f;

        //ゲームオーバを表示するテキスト
        private GameObject gameoverText;

        //スコアを表示するテキスト
        private GameObject scoreText;

        //スコア変数
        private int score = 0;

        // Use this for initialization
        void Start ()
        {
                //シーン中のGameOverTextオブジェクトを取得
                this.gameoverText = GameObject.Find("GameOverText");

                //シーン中のScoreTextオブジェクトを取得
                this.scoreText = GameObject.Find("ScoreText");
        }

        // Update is called once per frame
        void Update ()
        {
                //ボールが画面外に出た場合
                if (this.transform.position.z < this.visiblePosZ)
                {
                        //GameoverTextにゲームオーバを表示
                        this.gameoverText.GetComponent<Text> ().text = "Game Over";
                }
        }

        //衝突時に呼ばれる関数
        void OnCollisionEnter(Collision other)
        {

                //点数を加算する (大きい星:20 小さい星:15 大きい雲:10 小さい雲:5)
                if (other.gameObject.tag == "LargeStarTag")
                {
                        this.score += 20;
                }
                else if (other.gameObject.tag == "SmallStarTag")
                {
                        this.score += 15;
                }
                else if (other.gameObject.tag == "LargeCloudTag")
                {
                        this.score += 10;
                }
                else if (other.gameObject.tag == "SmallCloudTag")
                {
                        this.score += 5;
                }
                
                // Debug.Log("タグの中身=" + other.gameObject.tag);
                // Debug.Log("点数 = " + this.score);

                //ScoreTextにスコアを表示
                this.scoreText.GetComponent<Text> ().text = "SCORE" + this.score + "点!!";
        }
}