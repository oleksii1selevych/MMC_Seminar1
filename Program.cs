using seminar1NewVersion;
using System.Media;


byte[] audioBytes = System.IO.File.ReadAllBytes("seminar1TestAudio.wav");
const string deltaCodingFileName = "deltaCoding.wav";
const string averageDeltaCodingFileName = "averageDeltaCoding.wav";
const string subbandCodingFileName = "subbandCoding.wav";

var lpcAlgorithm = new LpcAlgorithm();
//double[] deltaCodingResultArray = lpcAlgorithm.Example1(audioBytes, audioBytes.Length);

//byte[] restoredDeltaByteArray = lpcAlgorithm.Example2(deltaCodingResultArray, deltaCodingResultArray.Length);
//using (FileStream byteToAudio = File.Create(deltaCodingFileName))
//    byteToAudio.Write(restoredDeltaByteArray, 0, restoredDeltaByteArray.Length);

//double[] averageSubstractionResult = lpcAlgorithm.Example3(audioBytes, audioBytes.Length, 4);
//byte[] averageRestoredResultArray = lpcAlgorithm.Example4(averageSubstractionResult, averageSubstractionResult.Length, 4);
//using (FileStream byteToAudio = File.Create(averageDeltaCodingFileName))
//    byteToAudio.Write(averageRestoredResultArray, 0, averageRestoredResultArray.Length);

(double[] a, double[] d) subbandCodingStreams = lpcAlgorithm.Example5(audioBytes, audioBytes.Length);
byte[] subbandCodingResultArray = lpcAlgorithm.Example6(subbandCodingStreams.a, subbandCodingStreams.d, audioBytes.Length, audioBytes);
using (FileStream byteToAudio = File.Create(subbandCodingFileName))
    byteToAudio.Write(subbandCodingResultArray, 0, subbandCodingResultArray.Length);



