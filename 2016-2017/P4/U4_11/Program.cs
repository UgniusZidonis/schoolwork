using System;
using System.IO;
using System.Collections;

namespace U4_11
{
	class Video
	{
		string name,
			   group,
			   ratio,
			   duration;
		int time;

		public Video(){
			name = "";
			group = "";
			ratio = "";
			time = new int();
		}

		public void Set(string productName, string productGroup, string aspectRatio, string duration){
			this.name = productName;
			this.group = productGroup;
			this.ratio = aspectRatio;
			this.duration = duration;

			time = 0;
			string[] timeSplit = duration.Split(':');

			for (int i = 0; i < timeSplit.Length; i++){
				time += (int)(int.Parse(timeSplit[timeSplit.Length - i - 1]) * Math.Pow(60, i));
			}
		}

		public string getName() { return name; }
		public string getGroup() { return group; }
		public int getDuration() { return time; }
		public string getRatio() { return ratio; }

		public override string ToString ()
		{
			string line;
			line = string.Format("{0,12} {1,16} {2,8} {3,13}", name, group, duration, ratio);
				return line;
		}

		public static bool operator <=(Video v1, Video v2) {
			int t;
			int g = String.Compare(v1.getGroup(), v2.getGroup(), StringComparison.CurrentCulture);
			if (v1.getDuration() > v2.getDuration()) t = -1; else if (v1.getDuration() == v2.getDuration()) t = 0; else t = 1;

			return g < 0 || (g == 0 && t > 0);
		}

		public static bool operator >=(Video v1, Video v2){
			int t;
			int g = String.Compare(v1.getGroup(), v2.getGroup(), StringComparison.CurrentCulture);
			if (v1.getDuration() > v2.getDuration()) t = -1; else if (v1.getDuration() == v2.getDuration()) t = 0; else t = 1;
			
			return g > 0 || (g == 0 && t < 0);
		}
	}

	class Container
	{
		int CMax = 100;
		Video[] v;
		int n;

		public Container(){
			v = new Video[CMax];
			n = 0;
		}

		public int get() { return n; }
		public Video get(int i) { return v[i]; }
		public void Set(Video obj) { v[n++] = obj; }

		public void Sort(){
			for (int i = 0; i < n - 1; i++){
				Video min = v[i];
				int min_i = i;
				for (int j = i; j < n; j++)
					if (min >= v[j]){
						min = v[j];
						min_i = j;
					}
				v[min_i] = v[i];
				v[i] = min;
			}
		}
	}

	class MainClass
	{
		const string CFin = "../../input.txt";
		const string CFout = "../../output.txt";

		public static void Main (string[] args)
		{
			if (File.Exists(CFout))
				File.Delete(CFout);
			Container videos = new Container();
			Container pirma = new Container();
			Container antra = new Container();

			ReadFromFile(CFin, ref videos);
			using (var fr = File.AppendText(CFout))
				fr.WriteLine("   Pradinis vaizdo klipų sąrašas");
			WriteToFile(CFout, videos);
			videos.Sort();

			FormArrayByRatio(videos, ref pirma, "4:3");
			FormArray_OneFromGroup(pirma, ref antra);

			using (var fr = File.AppendText(CFout))
				fr.WriteLine("   Surikiuotas atrinktų vaizdo klipų sąrašas");
			WriteToFile(CFout, antra);


		}

		static void ReadFromFile(string fv, ref Container C){
			using (StreamReader reader = new StreamReader(fv)){
				string line;

				while ((line = reader.ReadLine()) != null){
					string[] parts = line.Split(';');
					string name = parts[0].Trim();
					string group = parts[1].Trim();
					string duration = parts[2].Trim();
					string ratio = parts[3].Trim();

					Video vid = new Video();
					vid.Set(name, group, ratio, duration);
					C.Set(vid);
				}
			}
		}

		static void WriteToFile(string fv, Container C){
			const string viršus = 
				"------------------------------------------------------------\r\n" +
				" Pavadinimas   Produkto grupė   Trukmė   Kraštinių santykis\r\n" +
				"------------------------------------------------------------";

			using (var fr = File.AppendText(fv)){
				fr.WriteLine(viršus);

				for (int i = 0; i < C.get(); i++){
					fr.WriteLine(C.get(i).ToString());
				}

				fr.WriteLine("\nBendra visų vaizdo klipų trukmė: {0,1}\n", ConvertTimeToString(DurationSum(C)));
			}
		}

		static int DurationSum(Container C){
			int sum = 0;

			for (int i = 0; i < C.get(); i++)
				sum += C.get(i).getDuration();

			return sum;
		}

		static void FormArrayByRatio(Container C, ref Container R, string ratio){
			for (int i = 0; i < C.get(); i++){
				if (C.get(i).getRatio() == ratio)
					R.Set(C.get(i));
			}
		}

		static void FormArray_OneFromGroup(Container C, ref Container R){
			string lastGroup = "";
			for (int i = 0; i < C.get(); i++){
				if (C.get(i).getGroup() != lastGroup){
					R.Set(C.get(i));
					lastGroup = C.get(i).getGroup();
				}
			}
		}

		static string ConvertTimeToString(int time){
			string duration = "";
			int h = 0;
			int m = 0;
			int s = 0;

			if (time >= 3600){
				h = time / 3600;
				time -= h * 3600;
			}
			if (time >= 60){
				m = time / 60;
				time -= m * 60;
			}
			s = time;

			if (h > 0)
				duration = string.Format("{0,1}:", h);
			if (m >= 10 || h == 0)
				duration += string.Format("{0,1}:", m);
			else
				duration += string.Format("0{0,1}:", m);
			if (s >= 10)
				duration += string.Format("{0,1}", s);
			else
				duration += string.Format("0{0,1}", s);

			return duration;
		}
	}
}
