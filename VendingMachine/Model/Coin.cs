using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace VendingMachine.Model {

    /// <summary>
    /// 硬貨クラス
    /// </summary>
    /// <remarks>この設計の理由は、基底クラスを参照して下さい。</remarks>
    public class Coin : MoneyBase {

        public Coin(MoneyType type /*, [CallerMemberName] string calledMethod*/): base(type) {

            //todo Reflectionを使って、MoneyFactory以外から呼び出されたときは、Exceptionにしようかな。

            //if(calledMethod == .... みたいな感じで、CompilerServicesの機能でクラス名なんとかならないかな？
        }
    }
}
