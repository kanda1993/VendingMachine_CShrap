using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model {
    
    /// <summary>
    /// お金を管理するクラスだよ！
    /// すごいよ！
    /// Singleton dayo!
    /// </summary>
    /// <remarks>
    /// Insert/Insertedは、投入金に関わる物の名称。
    /// 今後、自販機内に売上金/おつり用のプールを作ることになるので、予め名称を決定。
    /// </remarks>
    public class MoneyManager {

        protected static MoneyManager _instance;

        /// <summary>
        /// 投入金一覧。Dictを用いてお金種別毎に管理。
        /// 
        /// Key=お金種別, Value=お金List
        /// </summary>
        /// <remarks>Dictionaryなのは、MoneyTypeの重複を許さない為。</remarks>
        Dictionary<MoneyType, List<MoneyBase>> _insertedMoneyDict;

        /// <summary>
        /// Singleton dayo.
        /// </summary>
        private MoneyManager() {
            _insertedMoneyDict = new Dictionary<MoneyType, List<MoneyBase>>();
        }

        /// <summary>
        /// Singleton dayo.
        /// </summary>
        /// <returns></returns>
        public static MoneyManager GetInstance() {
            if (_instance == null) {
                _instance = new MoneyManager();
            }
            return _instance;
        }

        /// <summary>
        /// お金を作ります。
        /// 最終的には、ここだけでお金を作るようにします。
        /// </summary>
        /// <param name="moneyType"></param>
        /// <returns></returns>
        public MoneyBase CreateMoney(MoneyType moneyType) {
            MoneyFactory factory = MoneyFactory.GetInstance();
            MoneyBase money = factory.CreateMoney(moneyType);
            return money;
        }


        /// <summary>
        /// Moneyを、投入金として追加しますよ。
        /// </summary>
        /// <param name="money">お金</param>
        public void InsertMoney(MoneyBase money) {
            // 定義されてないEnumの値だったら弾く。"(MoneyType)9999"とか出来ちゃうから。
            if (!Enum.IsDefined(typeof(MoneyType), money.MoneyType)) {
                throw new InvalidProgramException("Not Allowed MoneyType.");
            }

            IList<MoneyBase> list = GetInsertedMoneyList(money.MoneyType);
            list.Add(money);
        }

        /// <summary>
        /// 投入金一覧から、追加したいお金種別のみのListをゲーット
        /// </summary>
        /// <param name="moneyType">お金種別</param>
        /// <returns></returns>
        private List<MoneyBase> GetInsertedMoneyList(MoneyType moneyType) {

            // 見つからなかったら作るよ。
            bool exist = _insertedMoneyDict.Any(s => s.Key == moneyType);
            if (!exist) {
                _insertedMoneyDict.Add(moneyType, new List<MoneyBase>());
            }

            List<MoneyBase> list = _insertedMoneyDict.Single(s => s.Key == moneyType).Value;
            return list;
        }

        /// <summary>
        /// 投入したお金が幾らか計算する。
        /// ドルとセントは計算でき・・・ますけどマイナスなのでえらいことになります。
        /// </summary>
        /// <returns></returns>
        public string CountInsertedMoney() {
            // 投入金額
            int sumValue = 0;

            // お金種別毎のListを回して、全体の投入金額を求める。
            foreach (IList<MoneyBase> list in _insertedMoneyDict.Values) {

                // list.Count > 0 と等価。
                if (list.Any()) {

                    // MoneyTypeから、お金の価値を求める。
                    // 現時点では、enumの数値=価値。そのうち変えます。
                    int value = (int)list.First().MoneyType;

                    // お金の価値 * List内のObject数 = そのMoneyType毎の総額
                    value = value * list.Count;
                    
                    // 投入金額へ加算
                    sumValue += value;
                }
            }

            return sumValue.ToString();
        } 


        /// <summary>
        /// とりあえずStringでお金の総数を返すよ。
        /// 
        /// 投入金も、払い戻ししたので0円にする。
        /// </summary>
        /// <returns></returns>
        public string ReturnInsertedMoney() { 
            string output = "";

            foreach (IList<MoneyBase> list in _insertedMoneyDict.Values) {
                if (list.Count > 0) {
                    string moneyType = list[0].MoneyType.ToString();

                    // "yen10000 x2, "
                    output += (moneyType + " x" + list.Count + ", ");
                }
            }

            // お金を吐き出したら、中身は空にする。
            InitializeInsertedMoney();

            return output;
        }

        /// <summary>
        /// 投入金を0にします。
        /// </summary>
        public void InitializeInsertedMoney() {
            _insertedMoneyDict.Clear();
        }

    }
}
