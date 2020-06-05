using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HELIX.ExceptionDLL;
using Helix.DBHelper.Model;

namespace Helix.DBHelper
{
    public static class QuestionManager
    {

        private static DB _DB;

        public static void Init(DB dB)
        {
            _DB = dB;
        }

        public static void Add_new_stage(string question_text, string correct_answer, string incorrect_answer_1, string incorrect_answer_2, string incorrect_answer_3, int selected_dificulty)
        {
            _DB.Add_new_stage(question_text, correct_answer, incorrect_answer_1, incorrect_answer_2, incorrect_answer_3, selected_dificulty);
        }

        public static void Update_stage( int stage_id, string question_text, string correct_answer, string incorrect_answer_1, string incorrect_answer_2, string incorrect_answer_3, int selected_dificulty)
        {
            _DB.Update_stage (stage_id, question_text, correct_answer, incorrect_answer_1, incorrect_answer_2, incorrect_answer_3, selected_dificulty);
        }

        public static Stages Get_stage_by_id(int stage_id)
        {
            Stages stage = _DB.GetStage(stage_id);

            return stage;
        }

        public static void Remove_stage_by_id(int stage_id)
        {
            if (_DB.RemoveStage_by_id(stage_id) == true) { };
        }

        //public static string AddFile(string filename, string fileCrc, long fileSize)
        //{
        //    return _DB.AddFileData(filename, fileCrc, fileSize);
        //}

        //private static List<int> GetSchedulesContainFile(string guid)
        //{
        //    if (guid == null)
        //        throw new HelixException(HelixExceptionCode.E00);
        //    List<int> scheduleIds = new List<int>();
        //    bool isBreak = false;
        //    var schedules = ScheduleManager.GetScheduleList();
        //    foreach (Engine.ScheduleModel.Schedule sch in schedules)
        //        foreach (Engine.ScheduleModel.ScheduleElement el in sch.Elements)
        //        {
        //            if (el.GUID == guid)
        //            {
        //                scheduleIds.Add(sch.Id.GetValueOrDefault());
        //                isBreak = true;
        //            }
        //            if (isBreak)
        //            {
        //                isBreak = false;
        //                break;
        //            }
        //        }
        //    return scheduleIds;
        //}

        //public static bool DeleteFile(int fileId, out List<int> scheduleIds)
        //{
        //    scheduleIds = GetSchedulesContainFile(_DB.GetFileGuidById(fileId));
        //    if (scheduleIds.Count > 0)
        //        return false;
        //    else
        //    {
        //        if (!_DB.RemoveFileData(fileId))
        //            throw new HelixException(HelixExceptionCode.E03);
        //        return true;
        //    }
        //}

        //public static DataSet GetFilesDataSet(int? scheduleId = null)
        //{
        //    return _DB.GetFilesDataSet(scheduleId);
        //}

        //public static DataRow GetFileData(int fileId)
        //{
        //    var dataTable = GetFilesDataSet().Tables[0];
        //    foreach (DataRow row in dataTable.Rows)
        //        if ((int)row["id"] == fileId)
        //            return row;
        //    throw new HelixException(HelixExceptionCode.E03);
        //}
        //public static Helix.DBHelper.Model.FileMeta GetFileByGUID(string GUID)
        //{
        //    return _DB.GetFileByGUID(GUID);
        //}
    }
}
