using System.Collections;
using System.Collections.Generic;
using Pekemon.Battle;
using UnityEngine;
using System.IO;

namespace Pekemon
{

    interface IMoveTable
    {
        IList<Pekemon.Battle.IMove> GetData();
    }

    abstract class AbstractMoveTable : IMoveTable
    {
		protected IList<IMove> MoveList
		{
			get;
			set;
		}
        public IList<IMove> GetData()
        {
			Load();

			return MoveList;
        }

		protected abstract void Load();
    }

    class CsvMoveTable : AbstractMoveTable
    {
        protected override void Load()
        {
            var csv = Resources.Load("test.csv") as TextAsset;
			using (StringReader reader = new StringReader(csv.text))
			{
                string record = string.Empty;
                while ((record = reader.ReadLine()) != null)
				{
                    IDictionary<string, string> fields = new Dictionary<string, string>();
                    // IMoveオブジェクトに変換する処理を書く
				}
			}
        }
    }

    public class MoveTable : MonoBehaviour
    {
        public IList<Pekemon.Battle.IMove> MoveList
        {
            get;
            private set;
        }

        void Awake()
        {
            IMoveTable table = new CsvMoveTable();
            MoveList = table.GetData();
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}