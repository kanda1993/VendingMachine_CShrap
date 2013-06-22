using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model {

    /// <summary>
    /// お金の種類。
    /// ひとまず、enumの値 = お金の価値。10000円 = 10000.
    /// </summary>
    /// <remarks>
    /// それぞれにクラス作ったほうが楽だけど、とりあえずお手軽だからこっちにしとく。
    /// </remarks>
    public enum MoneyType { 
        yen10000 = 10000,
        yen5000 = 5000,
        yen2000 = 2000,
        yen1000 = 1000,
        yen500 = 500,
        yen100 = 100,
        yen50 = 50,
        yen10 = 10,
        yen5 = 5,
        yen1 = 1,
        doller100 = -100,
        cent1 = -1,
    }

    /// <summary>
    /// お金の基底クラス。
    /// </summary>
    /// <remarks>
    /// ■ 基底クラスとした理由
    /// 当初、お金クラスはInterfaceかAbstractにする予定でした。
    /// 
    /// 今回、お金クラスに求める事は、
    ///   ・価値(幾らなのか)を持つこと
    ///   ・硬貨かお札かを持つこと
    /// の2点だけと考えています。
    /// 
    /// これは、多くの責務をお金クラスに与えると、
    /// お金クラスと、そのお金クラスを操作するクラスのそれぞれに、
    /// どこまでの責任を持たせるかがぼやけてしまう恐れがあると考えた為です。
    /// (よってMoneyManagerを作って、お金に関する操作を集約しています。)
    /// 
    /// ■ 基底クラスを継承した、お札クラス、硬貨クラスを作った理由
    /// 上記の通り、お金クラスに求められる事はシンプルなので、
    /// IMoneyやAbstractMoneyとして実装を硬貨とお札側に任せる必要はないと考え、
    /// 基底クラスで価値を持つ機能を提供して、基底クラスを継承した硬貨クラス、お札クラスを作ることにしました。
    /// 
    /// 本クラスを基底クラスではなく、本体として、中に硬貨かお札かというフラグを持たせる事も考えたのですが、
    /// 例えば電子マネーなど、他の決済手段を追加しやすい余地を残す為に分割しています。
    /// 
    /// 
    /// ■ お金の種類毎にクラスを作らなかった理由
    /// 10000円クラス、5000円クラスとしなかった理由は、
    /// 判定等を行うとき、クラスを列挙する際に抜けが出る可能性が高くなるからです。
    /// その点Enumを使用する場合は、MoneyType.XXX と候補が出るので、抜けがやや出にくいと考えています。
    /// 
    /// 正直、どの方法が良いかまだ結論が出ていません。
    /// </remarks>
    public class MoneyBase {

        private MoneyType _Value;

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>このクラスは直接インスタンス化させん。</remarks>
        /// <param name="value"></param>
        protected MoneyBase(MoneyType value) {
            _Value = value;
        }

        /// <summary>
        /// お金の種類
        /// </summary>
        public MoneyType MoneyType {
            get {
                return _Value;
            }
        }

    }
}
