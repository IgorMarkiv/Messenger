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
    public static class GameManager
    {

        private static DB _DB;

        public static void Init(DB dB)
        {
            _DB = dB;
        }

        public static Settings Get_game_settings_qestiion_count_hard()
        {
            Settings game_settings_qestiion_count_hard = _DB.Get_game_settings_qestiion_count_hard();
            return game_settings_qestiion_count_hard;
        }

        public static Settings Get_game_settings_question_count_medium()
        {
            Settings game_settings_qestiion_count_medium = _DB.Get_game_settings_question_count_medium();
            return game_settings_qestiion_count_medium;
        }

        public static Settings Get_game_settings_question_count_easy()
        {
            Settings game_settings_qestiion_count_easy = _DB.Get_game_settings_question_count_easy();
            return game_settings_qestiion_count_easy;
        }

        public static void Set_game_setings(string game_settings_question_count_easy, string game_settings_question_count_medium, string game_settings_question_count_hard)
        {
            _DB.Set_game_setings(game_settings_question_count_easy, game_settings_question_count_medium, game_settings_question_count_hard);
        }

        public static string init_game(int user_id, bool isTrueGame)
        {
            string game_session_key = _DB.Init_game(user_id, isTrueGame);
            return game_session_key;
        }

        public static long Get_active_game_id_by_user_id(int user_id, bool isTrueGame)
        {
            long game_id = _DB.Get_active_game_id_by_user_id(user_id, isTrueGame);
            return game_id;
        }

        public static Stages Get_Random_stage_by_level(int level, int user_id, bool isTrueGame)
        {
            Stages stage = _DB.Get_Random_stage_by_level(level, user_id, isTrueGame);
            return stage;
        }

        public static Stages Get_stage_by_stage_id(int? stage_id)
        {
            Stages stage = _DB.Get_stage_by_stage_id(stage_id);
            return stage;
        }

        public static void Set_active_stage_by_game_id(long game_id, int stage_id)
        {
            _DB.Set_active_stage_by_game_id(game_id, stage_id);
        }

        public static Games Check_if_user_have_active_game(int user_id, bool isTrueGame)
        {
            Games game = _DB.Check_if_user_have_active_game(user_id, isTrueGame);
            if(game != null)
            {
                return game;
            }
            else
            {
                return null;
            }
        }
        public static bool Check_if_user_can_start_game(int user_id, bool isTrueGame)
        {
            bool is_user_can_start_game = _DB.Check_if_user_can_start_game(user_id, isTrueGame);
            return is_user_can_start_game;
        }

        public static int? Check_if_user_have_active_stage(int user_id, bool isTrueGame)
        {
            int? if_user_have_active_stage = _DB.Check_if_user_have_active_stage(user_id, isTrueGame);
            return if_user_have_active_stage;
        }

        public static List<int> Stages_complete_count(long game_id)
        {
            List<int> stages_comlete_count = _DB.Check_stages_complete_count(game_id);
            return stages_comlete_count;
        }

        public static void Save_stage_result(long game_id, int stage_id, int level, bool is_crrect_answr /*, TimeSpan spent_time*/)
        {
            _DB.Save_stage_result(game_id, stage_id, level, is_crrect_answr);
        }

        public static void Submit_game(double game_id, bool isTrueGame_game)
        {
            _DB.Submit_game(game_id, isTrueGame_game);
        }

        public static void Global_Settings_Stop_game()
        {
            _DB.Global_Settings_Stop_game();
        }

        public static void Global_Settings_Start_game()
        {
            _DB.Global_Settings_Start_game();
        }

        public static bool  Check_global_settings_status()
        {
            if (_DB.Check_global_settings_status() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Stages Get_active_stage_by_active_game_id(long game_id)
        {
            Stages stage = _DB.Get_active_stage_by_active_game_id(game_id);
            return stage;
        }

        public static List<Games> get_all_user_games(int user_id)
        {
            List<Games> games = _DB.get_all_user_games(user_id);
            //if( games.Count != 0)
            //{
                return games;
            //}
            //else
            //{
            //    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //    return null;
            //}
        }

        public static int GetBestUserScore(int user_id)
        {
            int bestuserscore = _DB.GetBestUserScore(user_id);
            return bestuserscore;
        }

        public static int GetLastUserScore(int user_id)
        {

            int last_user_score = _DB.GetLastUserScore(user_id);
            return last_user_score;
        }

        public static int Get_user_percent_of_superiority(int user_id)
        {
            int user_percent_of_superiority = _DB.Get_user_percent_of_superiority(user_id);
            //if (user_percent_of_superiority != null)
            //{
            return user_percent_of_superiority;
            //}
            //else
            //{
            //    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //    user_percent_of_superiority = 0;
            //    return user_percent_of_superiority;
            //}
        }

        public static List<Game_detalis> Get_list_of_complete_game_detalies(double game_id)
        {
            List<Game_detalis> game_Detalis = _DB.Get_list_of_complete_game_detalies(game_id);
            //if(game_Detalis.Count != 0)
            //{
            return game_Detalis;
            //}
            //else
            //{  //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //    return null;
            //}
        }


        public static Game_detalis Get_incorrect_game_gamedetalies(long game_id)
        {
            Game_detalis if_have_gd_with_incorrect_answr = _DB.Get_incorrect_game_gamedetalies(game_id);
            if(if_have_gd_with_incorrect_answr != null)
            {
                return if_have_gd_with_incorrect_answr;
            }
            else
            {
                return null;
            }

        }

        public static string Get_game_session_key(long game_id)
        {
            string game_session_key = _DB.Chek_user_game_session_key(game_id);
            return game_session_key;
        }

        public static int Get_Global_Settings_time_to_answer()
        {
            return _DB.Get_Global_Settings_time_to_answer();
        }

        public static void Set_Global_Settings_time_to_answer(int time_to_answer)
        {
            _DB.Set_Global_Settings_time_to_answer(time_to_answer);
        }

        public static Games GetGameByGameId(long gameId)
        {
            Games game =_DB.GetGameByGameId(gameId);
            return game;
        }
    }
}