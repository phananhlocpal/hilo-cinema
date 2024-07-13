import Schedule from "../components/movieDetail_components/Schedule";
import MovieChooseDateComponent from "../components/movieDetail_components/MovieChooseDateComponent";
import {exampleSchedule, exampleMovie} from '../../data_example.js'
import { useState } from 'react';
import MovieContent from "../components/movieDetail_components/MovieContent.jsx";
import MovieOverviewComponent from "../components/movieDetail_components/MovieOverviewComponent.jsx";
import MovieSuggestionComponent from "../components/common_components/MovieSuggestionComponent.jsx";

const FilmDetail = () => {
    const [selectedDate, setSelectedDate] = useState(exampleSchedule[0].day); // Set initial date to the first date in the exampleSchedule

    const handleDateChange = (newDate) => {
        setSelectedDate(newDate);
    };

    return (
        <div>
            <div className="book__ticket__wrapper">
                <div className="relative bg-black flex justify-center w-full h-full">
                    <div className="absolute w-full h-full z-[300] bg-[#0003]"></div>
                    <div className="relative h-full ">
                        <div className="absolute top-0 -left-[0%] z-100">
                            <img alt="Blur Left" loading="lazy" width="342" height="680" decoding="async" data-nimg="1" className="w-full lg:h-[500px] object-cover lg:block hidden" src="/_next/static/media/blur-left.7a4f1851.png" />
                        </div>
                        <div className="relative">
                            <img alt="Img Movie" loading="lazy" width="1440" height="440" decoding="async" data-nimg="1" className="w-[860px] h-full md:h-full lg:h-[500px] object-fill duration-500 ease-in-out group-hover:opacity-10 scale-100 blur-0 grayscale-0)" src="https://cdn.galaxycine.vn/media/2024/5/6/inside-out-2-1_1714970465678.jpg" />
                            <button className="absolute top-[50%] left-[50%] -translate-x-2/4 -translate-y-2/4 z-[600]">
                                <img alt="play" loading="lazy" width="64" height="64" decoding="async" data-nimg="1" className="w-[40px] h-[40px] lg:w-[64px] lg:h-[64px] object-cover duration-500 ease-in-out group-hover:opacity-100 scale-100 blur-0 grayscale-0)" src="https://www.galaxycine.vn/_next/static/media/button-play.2f9c0030.png" />
                            </button>
                        </div>
                        <div className="absolute top-0 -right-[0%] z-100 lg:block hidden">
                            <img alt="Blur Right" loading="lazy" width="342" height="680" decoding="async" data-nimg="1" className="w-full lg:h-[500px] object-cover" src="/_next/static/media/blur-right.52fdcf99.png" />
                        </div>
                    </div>
                </div>
                <div className="grid grid-cols-1 screen1200:grid-cols-7 my-0 mx-auto screen1390:max-w-screen-xl xl:max-w-screen-screen1200 lg:max-w-4xl md:max-w-4xl gap-8 py-7 md:px-4 px-4">
                    <div className="book__left lg:col-span-5 w-full ">
                        <div className="book__film flex flex-col">
                            <MovieOverviewComponent />
                            <MovieContent movieModel={exampleMovie}/>
                            {/* <div className="line"></div> */}
                            <div className="movie__showtime">
                                <div className="movie__showtime-header">
                                    <span className="border-l-4 border-solid border-blue-10 mr-2"></span>
                                    <h1 className="mb-4 text-base inline-block capitalize font-bold">Lịch chiếu</h1>
                                </div>
                                <MovieChooseDateComponent schedule={exampleSchedule} selectedDate={selectedDate} onDateChange={handleDateChange} />
                                <Schedule data={exampleSchedule.find(item => item.day === selectedDate)?.detailSchedule || []} />
                            </div>
                            
                        </div>

                    </div>
                    <MovieSuggestionComponent/>

                </div>
            </div>
        </div>
    );
};

export default FilmDetail;
