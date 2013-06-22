using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model {

    /// <summary>
    /// お札クラス
    /// </summary>
    /// <remarks>この設計の理由は、基底クラスを参照して下さい。</remarks>
    public class Osatsu : MoneyBase {

        public Osatsu(MoneyType type): base(type) {
            //todo Reflectionを使って、MoneyFactory以外から呼び出されたときは、Exceptionにしようかな。
        }

    }
}
